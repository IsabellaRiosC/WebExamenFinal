function getModalContent(url) {
    $.get(url, function (data) {
        $('.modal-body').html(data);
    })
}


function closeModal(option) {
    //$('.modal-body').modal('hide');
    $("button[data-dismiss='modal']").click();
    $('.modal-body').html("");
    $('#succesMessage').removeClass('hidden');
    modifyAlertsClasses(option);
}

function modifyAlertsClasses(option) {
    $('#succesMessage').addClass('hidden');
    $('#editMessage').addClass('hidden');
    $('#deleteMessage').addClass('hidden');

    if (option === 'create') {
        $('#succesMessage').removeClass('hidden');
    }
    else if (option === 'edit') {
        $('#editMessage').removeClass('hidden');
    }
    else if (option === 'delete') {
        $('#deleteMessage').removeClass('hidden');
    }
}

