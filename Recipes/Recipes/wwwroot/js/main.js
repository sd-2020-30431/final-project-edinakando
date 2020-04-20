
var timeout;
$(document)
    .ajaxStart(function () {
        timeout = window.setTimeout(function () {
            timeout = null;
            $.LoadingOverlay("show", { maxSize: 40 });
        }, 300);
    })
    .ajaxComplete(function () {
        if (timeout) {
            window.clearTimeout(timeout);
            timeout = null;
        }
        $.LoadingOverlay("hide", { maxSize: 40 });
    })


jconfirm.defaults = {
    useBootstrap: false,
    type: 'orange',
    boxWidth: '35%',
    draggable: false,
    escapeKey: 'cancel',
}