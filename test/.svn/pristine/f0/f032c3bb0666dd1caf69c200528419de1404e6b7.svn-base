jQuery(document).ready(function () {

    $('#addnewlistmember').click(function () {
        if ($('#membermailaddress').val().trim() == "") {
            $('#membermailaddress').removeClass('alertred');
            $('#memberemailempty').show();
            $('#memeberemailnotvalid').hide();
        }
        else {

            if (ValidateEmail($('#membermailaddress').val())) {
                $('#memberemailempty').hide();
                $('#membermailaddress').removeClass('alertred');
                AddListMember($('#listid').val(), $('#membermailaddress').val(), $('#membername').val(), $('#memberdescription').val());
            }
            else {
                $('#memberemailempty').hide();
                $('#memeberemailnotvalid').show();
                $('#membermailaddress').addClass('alertred');
            }
            
        }
    });
    $('#membermailaddress').on('input propertychange', function () {

        if ($('#membermailaddress').val().trim() == "") {
            $('#membermailaddress').css("cssText", "border:1px solid red !important;");
            $('#memberemailempty').show();
            $('#memeberemailnotvalid').hide();
        }
        else {

            if (ValidateEmail($('#membermailaddress').val())) {
                $('#memberemailempty').hide();
                $('#memeberemailnotvalid').hide();
                $('#membermailaddress').css("cssText", "");   
            }
            else {
                $('#memeberemailnotvalid').show();
                $('#memberemailempty').hide();
                $('#membermailaddress').css("cssText", "border:1px solid red !important;");
            }

           
        }
    });


    $('#createnewmaillist').click(function () {
        if ($('#newmaillistname').val().trim() == "") {
            $('#newmaillistname').css("cssText", "border:1px solid red !important;");
        }
        else {
            $('#newmaillistname').css("cssText", "");
           CreateMailinglist($('#newmaillistname').val());
        }
    });

    $('#newmaillistname').on('input propertychange', function () {

        if ($('#newmaillistname').val().trim() == "") {
            $('#newmaillistname').css("cssText", "border:1px solid red !important;");
                    }
        else {
            $('#newmaillistname').css("cssText", "");
        }
    });
});

function AddListMember(lid, addr, mname, desc) {

    $.ajax({
        url: "/lists/addmember",
        type: "GET",
        dataType: "JSON",
        data: {
            listid: lid,
            address: addr,
            name: mname,
            description: desc
        },
        success: function (data) {
            alert(data);
        },
        error: function (data) {
        }
    })
    location.reload();
}

function CreateMailinglist(lname) {

    $.ajax({
        url: "/lists/createlist",
        type: "GET",
        dataType: "JSON",
        data: {
            listname: lname
        },
        success: function (data) {
            alert(data);
        },
        error: function (data) {
        }
    })
    location.reload();

}