using AutoMapper;
using Maturidade_Online.Dominio;
using Maturidade_Online.Filter;
using Maturidade_Online.Models;
using Maturidade_Online.Repositorio;
using Maturidade_Online.Servicos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maturidade_Online.Controllers
{
    public class ProjetoController : Controller
    {
        [Autorizador]
        public ActionResult Manter(int? id)
        {
            var projetoModel = new ProjetoModel();
            using (var contexto = new ContextoDeDados())
            {
                var caracteristicaServico = ServicoDeDependencia.MontarCaracteristicaServico(contexto);
                var subtopicosServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                var projetoServico = ServicoDeDependencia.MontarProjetoServico(contexto);
                var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);
                var caracteristicas = caracteristicaServico.Listar();
                var subtopicos = subtopicosServico.Listar();
                projetoModel.PilaresPontuacao = pilarServico.ListarPontuacaoTotal();

                if (id.HasValue && id.Value > 0)
                {
                    var projeto = new Projeto() { Id = id.Value };
                    var projetoDaBase = projetoServico.BuscarPorId(projeto);
                    if (projetoDaBase != null)
                    {
                        projetoModel = Mapper.Map<Projeto, ProjetoModel>(projetoDaBase);
                    }
                }
                projetoModel.ListaDeCaracteristicas = caracteristicas;
                projetoModel.ListaDeSubtopicos = subtopicos;
            }
            return View("Projeto", projetoModel);
        }

        [Autorizador]
        public ActionResult Salvar(ProjetoModel projetoModel)
        {
            if (ModelState.IsValid)
            {
                using (var contexto = new ContextoDeDados())
                {
                    //Converter Caracteristica
                    var caracteristicaService = ServicoDeDependencia.MontarCaracteristicaServico(contexto);
                    var caracteristicaBanco = caracteristicaService.Listar();
                    var listaCaracteristica = caracteristicaBanco.Where(s => projetoModel.IdsCaracteristicas.Any(c => c == s.Id)).ToList();

                    //Converter Subtópico
                    var subtopicoService = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                    var subtopicoBanco = subtopicoService.Listar();
                    var listaSubtopico = subtopicoBanco.Where(s => projetoModel.IdsSubtopicos.Any(c => c == s.Id)).ToList();

                    //Adicionar no projeto
                    var projeto = new Projeto();
                    if (projetoModel.Id.HasValue)
                    {
                        projeto.Id = projetoModel.Id.Value;
                    }
                    projeto.Nome = projetoModel.Nome;
                    projeto.Caracteristicas = listaCaracteristica;
                    projeto.Subtopicos = listaSubtopico;

                    var usuarioService = ServicoDeDependencia.MontarUsuarioServico(contexto);
                    var projetoServico = ServicoDeDependencia.MontarProjetoServico(contexto);
                    var usuarioAutenticado = new Usuario() { Email = ServicoDeAutenticacao.UsuarioLogado.Email };

                    try
                    {
                        projetoServico.Persistir(projeto, usuarioAutenticado);
                    }
                    catch (UsuarioException e)
                    {
                        ModelState.AddModelError("", e.Message);
                    }
                }
            }

            return RedirectToAction("Manter");
        }

        [Autorizador]
        public ActionResult Excluir(int id)
        {
            using (var contexto = new ContextoDeDados())
            {
                var usuarioAutenticado = new Usuario() { Email = ServicoDeAutenticacao.UsuarioLogado.Email };
                var projeto = new Projeto() { Id = id };
                var projetoServico = ServicoDeDependencia.MontarProjetoServico(contexto);
                var projetoDaBase = projetoServico.BuscarPorId(projeto);

                try
                {
                    projetoServico.Remover(projetoDaBase, usuarioAutenticado);
                }
                catch (UsuarioException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View("Projeto");
        }
        /*
                public ActionResult GerarGrafico()
                {
                    var projetosViewModel = new ProjetoListarViewModel();

                    using (var contexto = new ContextoDeDados())
                    {

                        var projetoServico = ServicoDeDependencia.MontarProjetoServico(contexto);
                        var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);
                        var pilaresPontuacoesTotais = pilarServico.ListarPontuacaoTotal();


                        var pilaresBanco = pilarServico.Listar();

                        var listaDePilarViewModel = new List<ProjetoListarPilarViewModel>();

                        foreach (var pilar in pilaresPontuacoesTotais)
                        {
                            var pilarViewModel = new ProjetoListarPilarViewModel();
                            pilarViewModel.Titulo = pilar.Titulo;
                            pilarViewModel.Pontuacao = pilar.PontuacaoTotal;

                            listaDePilarViewModel.Add(pilarViewModel);
                        }


                        return PartialView("_Grafico", listaDePilarViewModel);
                    }

                }

            */

        [Autorizador]
        public ActionResult Listar()
        {
            var projetosViewModel = new List<ProjetoListarViewModel>();

            using (var contexto = new ContextoDeDados())
            {
                var projetoServico = ServicoDeDependencia.MontarProjetoServico(contexto);
                var projetos = projetoServico.Listar();

                foreach (var projeto in projetos)
                {
                    var projetoViewModel = gerarProjetoFormatado(projeto, contexto);
                    projetoViewModel.Id = projeto.Id;
                    projetoViewModel.Nome = projeto.Nome;
                    projetoViewModel.CriadorId = projeto.UsuarioId;
                    projetosViewModel.Add(projetoViewModel);
                }
            }

            return View("Listar", projetosViewModel);
        }



        private List<ProjetoListarPilarViewModel> CalcularPercentual(List<PilarPontuacao> pilaresRestricao, List<PilarPontuacao> pilaresAtual, List<ProjetoListarPilarViewModel> modelo)
        {
            var pilaresViewModel = new List<ProjetoListarPilarViewModel>();
            foreach (var pilar in modelo)
            {
                var pilarAtual = pilaresAtual.FirstOrDefault(_ => _.Id == pilar.Id);
                var pilarRestricao = pilaresRestricao.FirstOrDefault(_ => _.Id == pilar.Id);

                if (pilarAtual != null && pilarRestricao != null)
                {
                    pilaresViewModel.Add(new ProjetoListarPilarViewModel()
                    {
                        Id = pilarAtual.Id,
                        Titulo = pilarAtual.Titulo,
                        Percentual = (pilarAtual.PontuacaoTotal * 100) / pilarRestricao.PontuacaoTotal
                    });
                }
                else
                {
                    pilaresViewModel.Add(pilar);
                }
            }
            return pilaresViewModel;
        }

      public JsonResult ArrayParaGrafico(int[] dados)
        {
            var subtopicos = dados.Select(c => new Subtopico() { Id = c }).ToList();

            using (var contexto = new ContextoDeDados())
            {
                var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);
                var subtopicoServico = ServicoDeDependencia.MontarSubtopicoServico(contexto);
                var lista = new List<Subtopico>();
                foreach (var subtopico in subtopicos)
                {
                    var subtopicoBase = subtopicoServico.BuscarPorId(subtopico);
                    lista.Add(subtopicoBase);
                }

                return Json(lista, JsonRequestBehavior.AllowGet);
            }

        }

        

        private List<PilarPontuacao> AgrupadorDePilar(ICollection<Caracteristica> caracteristicas)
        {
            var pilares = new List<PilarPontuacao>();
            foreach (var caracteristica in caracteristicas)
            {
                foreach (var subtopico in caracteristica.Subtopicos)
                {
                    var pilar = pilares.FirstOrDefault(_ => _.Id == subtopico.PilarId);
                    if (pilar != null)
                    {
                        pilar.PontuacaoTotal += subtopico.Pontuacao;
                    }
                    else
                    {
                        pilares.Add(new PilarPontuacao()
                        {
                            Id = subtopico.PilarId,
                            Titulo = subtopico.Pilar.Titulo,
                            PontuacaoTotal = subtopico.Pontuacao
                        });
                    }
                }
            }
            return pilares;
        }

        private List<PilarPontuacao> AgrupadorDePilar(ICollection<Subtopico> subtopicos)
        {
            var pilares = new List<PilarPontuacao>();
            foreach (var subtopico in subtopicos)
            {
                var pilar = pilares.FirstOrDefault(_ => _.Id == subtopico.PilarId);
                if (pilar != null)
                {
                    pilar.PontuacaoTotal += subtopico.Pontuacao;
                }
                else
                {
                    pilares.Add(new PilarPontuacao()
                    {
                        Id = subtopico.PilarId,
                        Titulo = subtopico.Pilar.Titulo,
                        PontuacaoTotal = subtopico.Pontuacao
                    });
                }
            }
            return pilares;
        }

        private ProjetoListarViewModel gerarProjetoFormatado(Projeto projeto, ContextoDeDados contexto)
        {
            var projetoViewModel = new ProjetoListarViewModel();
            var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);
            var pilares = pilarServico.Listar();
            ViewBag.pilaresPontuacaoTotal = pilares;

            var mapeamentoCatategorias = AgrupadorDePilar(projeto.Caracteristicas);
            var mapeamentoSubtopicos = AgrupadorDePilar(projeto.Subtopicos);

            var listaDePilaresModelo = new List<ProjetoListarPilarViewModel>();
            foreach (var pilar in pilares)
            {
                listaDePilaresModelo.Add(new ProjetoListarPilarViewModel()
                {
                    Id = pilar.Id,
                    Titulo = pilar.Titulo,
                    Percentual = 0
                });
            }
            var listaDePilares = CalcularPercentual(mapeamentoCatategorias, mapeamentoSubtopicos, listaDePilaresModelo);
            projetoViewModel.Pilares = listaDePilares;

            return projetoViewModel;
        }

    }
}