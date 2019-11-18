// JA DA TELA DE CADASTRO DE FORNECEDOR
$(document).ready(function () {
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('.input-your-tel').mask('(99) 99999-9999').focusout(function (event) {
        let target, phone, element;
        target = (event.currentTarget) ? event.currentTarget : event.srcElement;
        phone = target.value.replace(/\D/g, '');
        element = jQuery(target);
        element.unmask();
        if (phone.length > 10) {
            element.mask("(99) 99999-9999");
        } else {
            element.mask("(99) 9999-99999");
        }
    });
    $('.money2').mask("#.##0,00", { reverse: true });
    $('.number').mask("000");

    function CheckListCheckOnlyOne(chk) {
        var chkList = $(chk).parents('table').find('input[type=checkbox]');
        for (var i = 0; i < chkList.length; i++) {
            if (chkList[i] != chk && chk.checked) {
                chkList[i].checked = false;
            }
        }
    }

    $(function () {
        $('#cblNumber input[type=checkbox]').click(function () {
            CheckListCheckOnlyOne(this);
        });
    });
});

// JS TELA DE LISTAR FORNECEDORES
$(document).ready(function () {
    $('.gdvRequestItems').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        dom: 'Bfrtip',
        stateSave: true,

        buttons: [
            {
                extend: 'pdf',
                text: '<i class="fa fa-file-pdf-o fa-lg"></i> Gerar PDF',
                titleAttr: 'PDF',
                exportOptions: {
                    columns: ':visible'
                }
            },
        ],

        language: {
            sProcessing: "A processar...",
            sLengthMenu: "Mostrar _MENU_ registros",
            sZeroRecords: "Não foram encontrados resultados",
            sInfo: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            sInfoEmpty: "Mostrando de 0 até 0 de 0 registros",
            sInfoFiltered: "(filtrado de _MAX_ registros no total)",
            sInfoPostFix: "",
            sSearch: "Procurar:",
            sUrl: "",
            oPaginate: {
                sFirst: "Primeiro",
                sPrevious: "Anterior",
                sNext: "Seguinte",
                sLast: "Último",
            },
            buttons: {
                colvis: 'Selecione colunas',
                copyTitle: 'Copiar',
                copySuccess: { 1: "Copiado 1 linha para área de transferência", _: "Copiado %d linhas para área de transferência" }
            }
        }
    });

    $('.defaulttable').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": false,
        "info": true,
        "autoWidth": false,
        "order": [[1, 'desc']],

        language: {
            sProcessing: "A processar...",
            sLengthMenu: "Mostrar _MENU_ registros",
            sZeroRecords: "Não foram encontrados resultados",
            sInfo: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            sInfoEmpty: "Mostrando de 0 até 0 de 0 registros",
            sInfoFiltered: "(filtrado de _MAX_ registros no total)",
            sInfoPostFix: "",
            sSearch: "Procurar:",
            sUrl: "",
            oPaginate: {
                sFirst: "Primeiro",
                sPrevious: "Anterior",
                sNext: "Seguinte",
                sLast: "Último",
            },
            buttons: {
                colvis: 'Selecione colunas',
                copyTitle: 'Copiar',
                copySuccess: { 1: "Copiado 1 linha para área de transferência", _: "Copiado %d linhas para área de transferência" }
            }
        }
    });

    $('.gdvItems').DataTable({
        "paging": false,
        "lengthChange": false,
        "searching": false,
        "ordering": false,
        "info": false,
        "autoWidth": false
    });
})