$(function () {
  paginacao.iniciar();
});

var paginacao = {}

paginacao.paginaAtual = 0;

paginacao.CarregarLista = function () {
  $.get(
       'CarregarLista',
       {
         pagina: paginacao.paginaAtual
       }
   )
   .then(function (resultado) {
     $('#container-lista').html(resultado);
     paginacao.registrarBindsDeBotoes();
   });
}

paginacao.voltarPagina = function () {
  if (paginacao.paginaAtual > 0) {
    paginacao.paginaAtual--;
    paginacao.CarregarLista();
  }
}

paginacao.avancarPagina = function () {
  paginacao.paginaAtual++;
  paginacao.CarregarLista();
}

paginacao.registrarBindsDeBotoes = function () {
  paginacao.$btnVoltarPagina.attr('disabled', paginacao.paginaAtual === 0);

  var ultimaPagina = !!$('.table').data("ultima-pagina");
  paginacao.$btnAvancarPagina.attr('disabled', ultimaPagina);
  paginacao.$btnDescricao = $('.descricao');

  if (paginacao.$btnDescricao.click(function (event) {
      event.preventDefault();
      $('[data-toggle="popover"]').popover();
  }));


  $('.btn-excluir').click(function (event) {
    event.preventDefault();
    $('#modal-excluir').modal('show')
  });
}

paginacao.bindDaModalExcluir = function(){
  $('#modal-link-excluir').click(function (event) {
    event.preventDefault();
    let url = $('.btn-excluir').prop('href');
    paginacao.excluirRegistro(url);
  });
}

paginacao.excluirRegistro = function (url) {
  $.post(url)
    .then(function () {
      paginacao.CarregarLista();
      $('#modal-excluir').modal('hide');
    })
    .fail(function (resultado) {
      $('#modal-excluir').modal('hide');
      $('.mensagem').text(JSON.parse(resultado.responseText).message);
      $('#modal-erro').modal('show');

    });
}

paginacao.configurarBotoesDeNavegacao = function () {
  paginacao.$btnVoltarPagina.click(paginacao.voltarPagina);
  paginacao.$btnAvancarPagina.click(paginacao.avancarPagina);
}

paginacao.iniciar = function () {
  paginacao.$btnVoltarPagina = $("#btn-voltar-pagina");
  paginacao.$btnAvancarPagina = $("#btn-avancar-pagina");

  paginacao.configurarBotoesDeNavegacao();
  paginacao.CarregarLista();
  paginacao.bindDaModalExcluir();
}