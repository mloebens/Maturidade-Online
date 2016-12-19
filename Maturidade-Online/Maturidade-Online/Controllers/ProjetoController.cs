using AutoMapper;
using Maturidade_Online.Dominio;
using Maturidade_Online.Filter;
using Maturidade_Online.Models;
using Maturidade_Online.Repositorio;
using Maturidade_Online.Servicos;
using System;
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
                var caracteristicas = caracteristicaServico.Listar();
                var subtopicos = subtopicosServico.Listar();


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

        [Autorizador]
        public ActionResult Listar()
        {


            var projetosViewModel = new List<ProjetoListarViewModel>();

            using (var contexto = new ContextoDeDados())
            {
                var projetoServico = ServicoDeDependencia.MontarProjetoServico(contexto);
                var pilarServico = ServicoDeDependencia.MontarPilarServico(contexto);
                var pilaresPontuacoesTotais = pilarServico.ListarPontuacaoTotal();

                ViewBag.pilaresPontuacaoTotal = pilaresPontuacoesTotais;

                IEnumerable<Projeto> projetosDaBase = new List<Projeto>();
                projetosDaBase = projetoServico.Listar();

                foreach (var projeto in projetosDaBase)
                {
                    var projetoViewModel = new ProjetoListarViewModel();
                    projetoViewModel.Id = projeto.Id;
                    projetoViewModel.Nome = projeto.Nome;
                    projetoViewModel.CriadorId = projeto.UsuarioId;

                    var pilaresDoProjeto = projeto.Subtopicos.GroupBy(s =>
                       new { Id = s.PilarId })
                           .Select(s => new { Id = s.Key.Id, Total = s.Sum(_ => _.Pontuacao) }).ToList();

                    var projetoListaPilaresViewModel = new List<ProjetoListarPilarViewModel>();
                    foreach (var pilarPontuacaoTotal in pilaresPontuacoesTotais)
                    {
                        var projetoListaPilarViewModel = new ProjetoListarPilarViewModel();
                        projetoListaPilarViewModel.Id = pilarPontuacaoTotal.Id;
                        projetoListaPilarViewModel.Titulo = pilarPontuacaoTotal.Titulo;

                        var pilarEncontrado = pilaresDoProjeto.FirstOrDefault(_ => _.Id == pilarPontuacaoTotal.Id);
                        projetoListaPilarViewModel.Pontuacao = pilarEncontrado != null ? pilarEncontrado.Total : 0;


                        var pontuacaoAtual = projetoListaPilarViewModel.Pontuacao == 0 ? 1 : projetoListaPilarViewModel.Pontuacao;
                        var percentualDePontuacao = pontuacaoAtual * 100 / pilarPontuacaoTotal.PontuacaoTotal;
                        string cor = "amarelo";
                        if (percentualDePontuacao <= 25)
                        {
                            cor = "vermelho";
                        }
                        if (percentualDePontuacao >= 76)
                        {
                            cor = "verde";
                        }
                        projetoListaPilarViewModel.cor = cor;

                        projetoListaPilaresViewModel.Add(projetoListaPilarViewModel);
                    }

                    projetoViewModel.Pilares = projetoListaPilaresViewModel;

                    projetosViewModel.Add(projetoViewModel);

                }

                return View("Listar", projetosViewModel);
            }
        }
    }
}