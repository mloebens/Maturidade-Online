$(document).ready(function () {
  $("#opcoes").select2();

  
  MaturidadeOnline.Inicializar();
});


MaturidadeOnline = {}


MaturidadeOnline.Inicializar = function () {
  MaturidadeOnline.bindsDeBotoes();
}

MaturidadeOnline.bindsDeBotoes = function () {
  $('.btn-excluir').click(function (event) {
    event.preventDefault();
    $('#modal-excluir').modal('show')
    $('#modal-link-excluir').prop('href', $('.btn-excluir').prop('href'));
  });
}

var $listagemSubtopicos = $('#container-subtopicos-dados');




$("#opcoes").change(function () {

    console.log('ola');
    let idsCaracteristicas = $(this).select2('data').map(c => parseInt(c.id))
    console.log('idsCaracteristicas', idsCaracteristicas);
    if (idsCaracteristicas.length == 0) {
    }
    const urlGet = '@Url.Action("PesquisarSubtopicos", "Subtopico")';
    jQuery.ajaxSettings.traditional = true;
    $.get(urlGet, { idsCaracteristicas })
        .done(response => {
            console.log('response', response);
            $listagemSubtopicos.html(response);
        });
    //let idCaracteristica = parseInt($(this).select2('data')[0].id);
    //console.log('idCaracteristica', idCaracteristica);
    //console.log('this', $(this).select2('data')[0].text);
    //console.log('subTopicos', $listagemSubtopicos)
    //$listagemSubtopicos.show();

});
