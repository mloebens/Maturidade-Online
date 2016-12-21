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

  $('.btn-excluir').click(function (event) {
    event.preventDefault();
    $('#modal-excluir').modal('show')
    $('#modal-link-excluir').prop('href', $('.btn-excluir').prop('href'));
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
}