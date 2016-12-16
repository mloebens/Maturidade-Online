﻿using AutoMapper;
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
            using (var contexto = new ContextoDeDadosEF())
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
                using (var contexto = new ContextoDeDadosEF())
                {
                    var projeto = Mapper.Map<ProjetoModel, Projeto>(projetoModel);
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

            return View("Projeto");
        }

        [Autorizador]
        public ActionResult Excluir(int id)
        {
            using (var contexto = new ContextoDeDadosEF())
            {
                var usuarioAutenticado = new Usuario() { Email = ServicoDeAutenticacao.UsuarioLogado.Email };
                var projeto = new Projeto() { Id = id };
                var projetoServico = ServicoDeDependencia.MontarProjetoServico(contexto);
                var projetoDaBase = projetoServico.BuscarPorId(projeto);

                try
                {
                    projetoServico.Remover(projetoDaBase, usuarioAutenticado);
                }
            }

            return View("Projeto");
        }


        // Partial View
        [Autorizador]
        public ActionResult PesquisarSubtopicos(int[] idsCaracteristicas)
        {
            // TODO: consultar banco
            var subtopicos = new[]{
                new Subtopico() { Id = 1, Pontuacao = 5, Nome = "Subtópico 1" },
                new Subtopico() { Id = 2, Pontuacao = 7, Nome = "Subtópico 2" }
            };

            return PartialView("_Subtopicos", subtopicos);
        }


    }
}