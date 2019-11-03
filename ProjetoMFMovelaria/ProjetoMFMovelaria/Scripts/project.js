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