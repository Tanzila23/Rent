"Use Strict";


function ChallanNumber(vInvoice_No) {

    // var vChallanNumber = ChallanNumber;
    if (vInvoice_No !== '') {

        $.ajax({
            type: "POST",
            url: "/SalesOrder/GetInvoiceInfo",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(
                {
                    _Invoice_No: vInvoice_No
                }
            ),
            success: function (response) {

                // console.log(response);

                if (response.First.length > 0) {

                    console.log(response.First);
                    $('#mstrTable tr').not(function () { return !!$(this).has('th').length; }).remove();
                    var result = "";

                    for (var i = 0; i < response.First.length; i++) {
                        result += "<tr id='" + response.First[i].Article + "' data-refid='" + response.First[i].Article + "'><td style='text-align: center;border: 1px solid #d4000040;'>" + response.First[i].Article + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.First[i].Size + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.First[i].Quantity + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.First[i].MRP + "৳</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.First[i].Discount + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.First[i].NetAmt + "</td>";

                    }
                    $('#mstrTable').append(result);
                    $('#ChallanNo').attr("disabled", true);

                    //  $("#PickingNumber").attr("disabled", false);
                    $('#SalesOrderNo').val(response.First[0]['SalesOrderNo']);
                    $('#PickerName').val(response.First[0]['PickerName']);
                    $('#ChannelName').val(response.First[0]['DCHANNEL']);
                    $('#CustomerName').val(response.First[0]['Customer']);
                    $('#Discount').val(response.First[0]['DiscAllowed']);
                    $('#Total_Quantity').val(response.First[0]['Tqty']);
                    $('#Total_Item').val(response.First[0]['TArt']);
                    $('#Total_GrossAmount').val(response.First[0]['TGrss']);
                    $('#Total_Discount').val(response.First[0]['TDisc']);
                    $('#Total_VAT').val(response.First[0]['TVat']);
                    $('#Total_NetAmount').val(response.First[0]['TNet']);
                    $('#Total_NetPayAmount').val(response.First[0]['TNet']);

                } else {
                    $('#ChallanNo').val("");
                    PlaySound();
                    toastr.error("Please Check Challan No", "Your provide Challan no in Invalid. Please try another",
                        {
                            "positionClass": "toast-top-right",
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "closeButton": true,
                            "preventDuplicates": true
                        });
                    e.preventDefault();

                }
            },
            failure: function (response) {

                location.reload();
            },
            error: function (response) {

                location.reload();
            }
        });

    } else {
        // alert(vInvoice_No);
    }
}

$('#ChallanNo').keypress(function (e) {

    var code = e.keyCode;//? e.keyCode : e.which;
    if (code === 13) {
        var vInvoice_No = $('#ChallanNo').val();
        ChallanNumber(vInvoice_No);
    }
});




function Back_click() {

    location.reload();
}

$('#Modal_Item_Search #Item_Search').keyup(function (e) {

    var vItem = $('#Item_Search').val();


    switch (e.keyCode) {
        case 38: {//up arrow
            if (vItem != undefined) {
                $('#Modal_Item_Search #Item_Search').blur();
                $('#btn_SaleItem_ModalSearch').focus();
            } else {
                $('#Item_Search').focus();
            }

            return;

        }
        case 40: {//down arrow
            if (vItem != undefined) {
                $('#Modal_Item_Search #Item_Search').blur();
                $('#btn_SaleItem_ModalSearch').focus();
            } else {
                $('#Item_Search').focus();
            }

            return;

        }
        case 37: {//Left arrow
            Barcode_Item_Search();
            return;

        }
        case 39: {//Right arrow
            Barcode_Item_Search();
            return;

        } case 13: {
            return;
        }
        default: {
            Barcode_Item_Search();

            return true;
        }
    }

});

function Barcode_Item_Search() {
    var vSearch = $('#Modal_Item_Search #Item_Search').val();
    $.ajax({
        type: "POST",
        url: "/Channel/Modal_ItemSearch",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                Search: vSearch
            }
        ),
        success: function (response) {
            $('#Modal_Item_Search #tbl_Modal_ItemSearch').empty();
            var result = "";
            if (response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    result += "<tr id='" + response[i].Barcode + "'><td style='text-align:center;'>" + response[i].Article + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Barcode + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Name + "</td>" +
                        "<td style='text-align:center;'> " + response[i].SIZE + "</td>" +
                        "<td style='text-align:center;'> " + response[i].ColorName + "</td>" +
                        "<td style='text-align:center;'> " + response[i].MRP + "&nbsp;৳</td>" +
                        "<td style='text-align:center;'> " + response[i].Balance + "</td></tr>";
                    // "<td> <i class='glyphicon glyphicon-trash' onclick='delete_this(" + response[i].Barcode + ")'></i></td>";
                }
            }
            else {
                result += "<tr><td colspan='7' style='text-align:center;'>NO RESULT FOUND </td></tr>";
            }

            $('#Modal_Item_Search #tbl_Modal_ItemSearch').append(result);

        },

        failure: function (response) {

            location.reload();
        },
        error: function (response) {

            location.reload();
        }
    });



}

function Free_Barcode_Item_Search_master() {

    var vSearch = $('#Modal_Free_Item_Search #Free_Item_Search_master').val();
    var vCat_id = $('#FreeItemBarcode_master').attr("data-cat_id");
    var vSub_id = $('#FreeItemBarcode_master').attr("data-sub_ID");
    var vSeg_id = $('#FreeItemBarcode_master').attr("data-seg_ID");
    var vART_Code = $('#FreeItemBarcode_master').attr("data-art_code");
    //alert('Call Me' + vSearch);
    $.ajax({
        type: "POST",
        url: "/Channel/Free_All_Master_Barcode_Search",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                Barcode: vSearch,
                Cat_id: vCat_id,
                Sub_id: vSub_id,
                Seg_id: vSeg_id,
                ART_Code: vART_Code
            }
        ),
        success: function (response) {

            $('#Modal_Free_Item_Search #tbl_Modal_ItemSearch').empty();
            var result = "";
            console.log(response);
            if (response.length > 0) {
                for (var i = 0; i < response.length; i++) {

                    result += "<tr id='" + response[i].mBarcode + "'><td style='text-align:center;'>" + response[i].mBarcode + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Ratio + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Category + "</td>" +
                        "<td style='text-align:center;'> " + response[i].SubCat + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Segment + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Shortname + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Gender + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Color + "</td></tr>";
                }
            }
            else {
                result += "<tr><td colspan='7' style='text-align:center;'>NO RESULT FOUND </td></tr>";
            }


            $('#Modal_Free_Item_Search #tbl_Modal_ItemSearch').append(result);

        },

        failure: function (response) {

            location.reload();
        },
        error: function (response) {

            location.reload();
        }
    });



}

function Free_Barcode_Item_Search() {
    var vSearch = $('#Modal_Free_Item_Search #Free_Item_Search').val();
    var vCat_id = $('#FreeItemBarcode').attr("data-cat_id");
    var vSub_id = $('#FreeItemBarcode').attr("data-sub_ID");
    var vSeg_id = $('#FreeItemBarcode').attr("data-seg_ID");
    var vART_Code = $('#FreeItemBarcode').attr("data-art_code");


    $.ajax({
        type: "POST",
        url: "/Channel/Modal_Free_ItemSearch",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                Search: vSearch,
                Cat_id: vCat_id,
                Sub_id: vSub_id,
                Seg_id: vSeg_id,
                ART_Code: vART_Code
            }
        ),
        success: function (response) {


            $('#Modal_Free_Item_Search #tbl_Modal_Free_ItemSearch').empty();
            var result = "";
            if (response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    result += "<tr id='" + response[i].Barcode + "'><td style='text-align:center;'>" + response[i].Article + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Barcode + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Name + "</td>" +
                        "<td style='text-align:center;'> " + response[i].SIZE + "</td>" +
                        "<td style='text-align:center;'> " + response[i].ColorName + "</td>" +
                        "<td style='text-align:center;'> " + response[i].MRP + "&nbsp;৳</td>" +
                        "<td style='text-align:center;'> " + response[i].Balance + "</td></tr>";
                    // "<td> <i class='glyphicon glyphicon-trash' onclick='delete_this(" + response[i].Barcode + ")'></i></td>";
                }
            }
            else {
                result += "<tr><td colspan='7' style='text-align:center;'>NO RESULT FOUND </td></tr>";
            }

            $('#Modal_Free_Item_Search #tbl_Modal_Free_ItemSearch').append(result);

        },

        failure: function (response) {

            location.reload();
        },
        error: function (response) {

            location.reload();
        }
    });



}

function qtyCheck() {
    var _value = $('#Item_Quantity').val();
    // alert(_value);


    _value = Math.abs(_value);
    _value = Math.round(_value);
    $('#Item_Quantity').val(_value);
    if (_value > 300) {
        PlaySound();
        toastr.error("Item Quantity Exceeded,Please Try again", "Item Quantity Exceeded", {
            "positionClass": "toast-top-right",
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "closeButton": true,
            "preventDuplicates": true
        });
        $('#Item_Quantity').val("");
    }

}

function FreeqtyCheck() {

    var _value = $('#FreeItem_Quantity').val();
    _value = Math.abs(_value);
    _value = Math.round(_value);
    $('#FreeItem_Quantity').val(_value);
    var vFreeqty = $('#freeqty_id').html();
    if (parseInt(_value) > parseInt(vFreeqty)) {
        PlaySound();
        toastr.error("Item Quantity Exceeded,Please Try again", "Item Quantity Exceeded", {
            "positionClass": "toast-top-right",
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "closeButton": true,
            "preventDuplicates": true
        });
        $('#FreeItem_Quantity').val("");
    }
}

function masterFreeqtyCheck() {
    var _value = $('#Master_FreeItem_Quantity').val();
    _value = Math.abs(_value);
    _value = Math.round(_value);
    $('#Master_FreeItem_Quantity').val(_value);
    var vFreeqty = $('#freeqty_id').html();
    if (parseInt(_value) > parseInt(vFreeqty)) {
        PlaySound();
        toastr.error("Item Quantity Exceeded,Please Try again", "Item Quantity Exceeded", {
            "positionClass": "toast-top-right",
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "closeButton": true,
            "preventDuplicates": true
        });
        $('#Master_FreeItem_Quantity').val("");

    }
}

$('#Modal_AddCustomer').on('hidden.bs.modal', function () {
    var vCustomer_ID = $("#Customer_ID").val();
    vCustomer_ID === '' ? $("#Customer_ID").focus() : $("#ItemBarcode").focus();
});

$('#Modal_AddCustomer').on('shown.bs.modal', function (e) {

    $("#Modal_Item_Search").modal("hide");
    $('#First_Name').val("");
    $('#Last_Name').val("");
    $('#Email_Address').val("");
    $('#Mobile_No').val($('#Customer_ID').val());
    $('#Mobile_No').focus();
});

function NewCustomerAdd() {

    var vMobile_No = $('#Mobile_No').val(),
        vEmail_Address = $('#Email_Address').val(),
        vFirst_Name = $('#First_Name').val(),
        vLast_Name = $('#Last_Name').val(),
        vGender = $('#Gender').val();


    $.ajax({
        type: "POST",
        url: "/Sales/Customer_Entry",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                _Contact_No: '0' + Math.abs(vMobile_No),
                _Email_Address: vEmail_Address,
                _First_Name: vFirst_Name,
                _Last_Name: vLast_Name,
                _Gender: vGender
            }),

        success: function (response) {

            if (response.length > 0) {

                $("#Customer_ID").val(vMobile_No);
                $("#Customer_Name").val('');
                if (response[0].CUSTOMER_NAME !== 'undefined')
                    $("#Customer_Name").val(response[0].CUSTOMER_NAME);

                $("#ItemBarcode").focus();

            }
            else {
                $("#Customer_ID").val('');
                $("#Customer_ID").focus();
                PlaySound();
                toastr.error("Can't Add Customer Mobile No Please, Try again", "Can't Add Customer Mobile No", {
                    "positionClass": "toast-top-right",
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "closeButton": true,
                    "preventDuplicates": true
                });
            }
            $("#Modal_AddCustomer").modal("hide");


        },

        failure: function (response) {
            //  alert(response.responseText);
            location.reload();
        },
        error: function (response) {
            // alert(response.responseText);
            location.reload();
        }
    });

    $("#Modal_AddCustomer").modal("hide");
}

function btnReprint() {
    var vMStatus = $('#Modal_FreeItem').attr("data-modal");
    if (vMStatus == "Close") {
        location.replace("/Channel/SingleBarcode_Reprint/");
    }
}

function btnPay_click() {

    var vORDERNO = $('#ChallanNo').val();
    //$('#btnPay').a
    $('#btnPay').prop('disabled', true);
    $.ajax({
        type: "POST",
        url: "/SalesOrder/PrintInvoice",
        contentType: "application/json; charset=utf-8",

        dataType: "json",
        data: JSON.stringify(
            {
                _ORDERNO: vORDERNO

            }),

        success: function (response) {
            if (response) {
             
                toastr.success("Invoice Genarate Sucessfully", "Sucessfully Invoice Genarate", {
                    "positionClass": "toast-top-right",
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "closeButton": true,
                    "preventDuplicates": true
                });
                var ur = '../../Report/ViewInvoice.aspx';
                //var ur =Html.
                $("#ReportFrame").attr("src", ur);

                $('#_Details').hide();
                $('#_Invoice').show();

              
            } else {

                PlaySound();
                toastr.error("Invoice Genarate Failed", "Invoice Genarate Failed , Please Try again", {
                    "positionClass": "toast-top-right",
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "closeButton": true,
                    "preventDuplicates": true
                });
                $('#_Details').show();
                $('#_Invoice').hide();
            }
            
        },
        failure: function (response) {
            PlaySound();
            alert(response.responseText);
            location.reload();

        },
        error: function (response) {
            PlaySound();
            alert(response.responseText);
            location.reload();
        }
    });



}

function Modal_AddCustomer() {
    $("#Modal_AddCustomer").modal("show");
}

function keyPress(e) {

    var keyCode = e.keyCode;
    var rowCount = 0;
    // alert(keyCode);

    switch (keyCode) {
        //keyCode = 113 Mean: F2 Button Press
        case 113:
            var vCare_By = $("#Care_By_Name").val();
            rowCount = $('#mstrTable tbody tr').length;
            if (rowCount === 0) {
                $("#ItemBarcode").focus();
                PlaySound();
                toastr.error("Please Enter Barcode First", "Enter a Barcode First", {
                    "positionClass": "toast-top-right",
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "closeButton": true,
                    "preventDuplicates": true
                });
                $('#btnPay').addClass('disabled');
                return;
            }
            if (vCare_By == undefined || vCare_By == "") {
                PlaySound();
                toastr.error("Please Enter Care By ID", "Enter Care By", {
                    "positionClass": "toast-top-right",
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "closeButton": true,
                    "preventDuplicates": true
                });
                $('#btnPay').addClass('disabled');
                $("#Care_By").val('');
                $("#Care_By").focus();
                return;
            }

            btnPay_click();
            break;
        case 115:
            //keyCode = 115 Mean: F4 Button Press
            var vMStatus = $('#Modal_FreeItem').attr("data-modal");
            var vMCoupon = $('#Modal_Coupon').attr("data-modal");


            if (vMStatus == "Close" && vMCoupon == "Close") {
                Modal_Item_Search();
            }
            //if (vMCoupon == "Close") {
            //    Modal_Item_Search();
            //}


            break;
        case 119:
            //keyCode = 119 Mean: F8 Button Press
            var vMStatus = $('#Modal_FreeItem').attr("data-modal");
            var vMCoupon = $('#Modal_Coupon').attr("data-modal");

            if (vMStatus == "Close" && vMCoupon == "Close") {
                rowCount = $('#mstrTable tbody tr').length;
                rowCount > 0 ? Park_Sale() : "";
            }


            break;
        case 120:
            //keyCode = 120 Mean: F9 Button Press

            var isDisabled = $('#btn_Recall').data('disabled');
            isDisabled === false ? Recall() : '';

            break;
        //case 118:
        //    //keyCode = 118 Mean: F7 Button Press
        //    Return()
        //    break;

        case 46:
            btnItemDlt();
            break;

        case 35:
            var vMStatus = $('#Modal_FreeItem').attr("data-modal");
            if (vMStatus == "Close") {
                Discard_Sale_Modal();
            }
            break;
        case 117:
            //  Discard_Sale_Modal();
            var vStatus = $('#freeqty_id').attr("data-status");

            if (vStatus == 'Single') {
                Modal_Free_Item_Search('single');
            } else {
                Modal_Free_Item_Search('master');
            }

            break;
        default:
            break;
    }
}

//function Return() {
//    // alert("Exchange");
//    location.replace("/Sales/Return/");
//}

function Modal_Item_Search() {
    var vMStatus = $('#Modal_FreeItem').attr("data-modal");
    if (vMStatus == "Close") {
        $("#Modal_AddCustomer").modal("hide");
        $("#Modal_Recall").modal("hide");
        $("#Modal_Park_Sale").modal("hide");
        $("#Modal_Discard_Sale").modal("hide");
        $("#Modal_ItemDlt").modal("hide");
        $("#Modal_Item_Search").modal("show");
    }


}

$('#Modal_Item_Search').on('shown.bs.modal', function (e) {

    $('#table_Item_Search tr').not(function () { return !!$(this).has('th').length; }).remove();
    $('#Modal_Item_Search').attr('data-modal', 'Open');
    $('#Modal_Item_Search #Item_Search').val($('#ItemBarcode').val());
    $('#Modal_Item_Search #Item_Search').focus();
    Barcode_Item_Search();

});

$('#Modal_Item_Search').on('hidden.bs.modal', function (e) {

    $('#Item_Search').val('');
    $('#Modal_Item_Search').attr('data-modal', 'Close');
    $('#Item_Quantity').focus();
});

$('#Modal_Recall').on('shown.bs.modal', function (e) {
    $("#Modal_Item_Search").modal("hide");
    $("#Modal_AddCustomer").modal("hide");
    $("#Modal_Park_Sale").modal("hide");
    $("#Modal_Discard_Sale").modal("hide");
    $("#Modal_ItemDlt").modal("hide");


    $('#tbl_Recall_Item tr').not(function () { return !!$(this).has('th').length; }).remove();
    $('#Modal_Recall').attr('data-modal', 'Open');
    $('#btn_Recall_Submit').focus();

    $.ajax({
        type: "POST",
        url: "/Channel/Single_Barcode_Hold_View",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (response) {

            $('#Modal_Recall #tbl_Recall_Item_Body').empty();
            var result = "";
            if (response.First.length > 0) {
                for (var i = 0; i < response.First.length; i++) {
                    result += "<tr id='" + response.First[i].Hold_MobileNo + "'  data-channel_ID='" + response.First[i].Channel_ID + "' data-partner_ID='" + response.First[i].Partner_ID + "'>" +
                        "<td style= 'text-align:center;'> " + response.First[i].SL + "</td>" +
                        "<td style= 'text-align:center;'> " + response.First[i].Quantity + "</td>" +
                        "<td style= 'text-align:center;'> " + response.First[i].Sub_Total + "</td>" +
                        "<td style= 'text-align:center;'> " + response.First[i].Hold_Time + "</td>" +
                        "<td style= 'text-align:center;'> " + response.First[i].Hold_MobileNo + "</td></tr > ";
                }
            }
            else {
                result += "<tr><td colspan='5' style='text-align:center;'>NO Hold FOUND </td></tr>";
            }
            $('#Modal_Recall #tbl_Recall_Item_Body').append(result);
        },


        failure: function (response) {
            //  alert(response.responseText);
            location.reload();
        },
        error: function (response) {
            //  alert(response.responseText);
            location.reload();
        }
    });

});

$('#Modal_Recall').on('hidden.bs.modal', function (e) {
    $('#Modal_Recall').attr('data-modal', 'Close');
    $("#ItemBarcode").focus();
});

$('#Modal_Park_Sale').on('shown.bs.modal', function (e) {

    $("#Modal_AddCustomer").modal("hide");
    $("#Modal_Item_Search").modal("hide");
    $("#Modal_Recall").modal("hide");
    $("#Modal_Discard_Sale").modal("hide");
    $("#Modal_ItemDlt").modal("hide");
    ///////////////////////////////

    $('#Park_Sale_Total_Quantity').val($('#Total_Quantity').val());
    $('#Park_Sale_Total_Amount').val($('#Total_NetAmount').val());
    $('#Park_Sale_Total_Item').val($('#Total_Item').val());



    $('#Park_Sale_Mobile_No').val('');
    $('#Park_Sale_Mobile_No').focus();

});

function Discard_Sale_Modal() {
    $("#Modal_Discard_Sale").modal("show");

}

$('#Modal_Discard_Sale').on('shown.bs.modal', function (e) {

    $("#Modal_AddCustomer").modal("hide");
    $("#Modal_Recall").modal("hide");
    $("#Modal_Park_Sale").modal("hide");
    $("#Modal_Item_Search").modal("hide");
    $("#Modal_ItemDlt").modal("hide");

    $('#btn_Discard_Sale').focus();
    $('#Modal_Discard_Sale').attr('data-modal', 'Open');

});

$('#Modal_Discard_Sale').on('hidden.bs.modal', function (e) {
    $('#Modal_Discard_Sale').attr('data-modal', 'Close');

});

function Discard_Sale() {

    $("#Modal_Discard_Sale").modal("hide");

    $.ajax({
        type: "POST",
        url: "/Channel/SingleInvoice_Discard",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            toastr.success("Your Sales Sucessfully Discard ", "Sucessfully Discard", {
                "positionClass": "toast-top-right",
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "closeButton": true,
                "preventDuplicates": true
            });
            setTimeout(function () { location.reload();; }, 2000);

        },
        failure: function (response) {
            PlaySound();
            // alert(response.responseText);
            location.reload();
        },
        error: function (response) {
            PlaySound();
            // alert(response.responseText);
            location.reload();
        }
    });
}

$('#Modal_ItemDlt').on('hidden.bs.modal', function (e) {
    $("#ItemBarcode").focus();
});

$('#Modal_ItemDlt').on('shown.bs.modal', function (e) {
    $("#Modal_AddCustomer").modal("hide");
    $("#Modal_Recall").modal("hide");
    $("#Modal_Park_Sale").modal("hide");
    $("#Modal_Item_Search").modal("hide");
    $("#Modal_Discard_Sale").modal("hide");
    $('#btn_item_barcode').focus();
    $('#Modal_ItemDlt').attr('data-modal', 'Open');
});

function btnItemDlt() {
    var vBarcode = $('#mstrTable tr.highlight').attr('id');
    if (vBarcode !== undefined) {
        $("#item_barcode").html(vBarcode);
        $("#btn_item_barcode").val(vBarcode);
        $("#Modal_ItemDlt").modal("show");

    }
    // alert("--- btnItemDlt" + vBarcode);

};

$('.ItemRowDlt').click(function (e) {
    var vBarcode = $(this).attr("value");

    $.ajax({
        type: "POST",
        url: "/Channel/Channel_SingleBarcode_Clear",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                _Barcode: vBarcode
            }
        ),
        success: function (response) {

            $('#mstrTable tr').not(function () { return !!$(this).has('th').length; }).remove();
            var result = "";
            if (response.length > 0) {

                for (var i = 0; i < response.length; i++) {
                    result += "<tr id='" + response[i].Barcode + "'><td style='text-align:center;'>" + response[i].Barcode + "</td>" +
                        "<td style='text-align:center;'>" + response[i].Size + "</td>" +
                        "<td style='text-align:center;'>" + response[i].Quantity + "</td>" +
                        "<td style='text-align:center;'>" + response[i].MRP + "</td>" +
                        "<td style='text-align:center;'>" + response[i].Discount + "</td>" +
                        "<td style='text-align:center;'>" + response[i].NetAmount + "</td>" +
                        "<td style='text-align:center;'>" +
                        "<a href='#' id='" + response[i].Barcode + "' onClick='btnItemDlt()'> <i class='fa fa-trash-o'></i></a></td> </tr>";

                    $('#Total_Discount').val(response[i].Total_Discount);
                    $('#Total_NetAmount').val(response[i].Total_NetAmount);
                    $('#Total_Quantity').val(response[i].Total_Quantity);
                    $('#Total_Item').val(response[i].Total_Item);
                    $('#Total_GrossAmount').val(response[i].Total_GrossAmount);
                    $('#Total_VAT').val(response[i].Total_VatAmount);
                    $('#Total_NetPayAmount').html(response[i].Total_NetAmount + "&nbsp;৳");
                }
            }
            else {
                $('#Total_Discount').val(0);
                $('#Total_NetAmount').val(0);
                $('#Total_Quantity').val(0);
                $('#Total_Item').val(0);
                $('#Total_GrossAmount').val(0);
                $('#Total_VAT').val(0);
                $('#Total_NetPayAmount').html(0 + "&nbsp;৳");
            }

            $('#mstrTable').append(result);
            $('#Coupon_div').html("Coupon");
            ParkSale_Recall_Check();
            PlaySound();
            toastr.success("Sucessfully Item Delete", "Sucessfully!! Deleted", {
                "positionClass": "toast-top-right",
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "closeButton": true,
                "preventDuplicates": true
            });
        },
        failure: function (response) {
            // alert(response.responseText);
            location.reload();
        },
        error: function (response) {
            //  alert(response.responseText);
            location.reload();
        }
    });
    $('table#mstrTable tr#' + vBarcode).remove();
    ParkSale_Recall_Check();
    $("#Modal_ItemDlt").modal("hide");
});

function highlight(tableInfo, tableIndex) {
    // Just a simple check. If .highlight has reached the last, start again  #mstrTable tbody tr
    if ((tableIndex + 1) > $('#' + tableInfo).length)
        tableIndex = 0;

    // Element exists?
    if ($('#' + tableInfo + ':eq(' + tableIndex + ')').length > 0) {
        // Remove other highlights
        $('#' + tableInfo).removeClass('highlight');

        // Highlight your target
        $('#' + tableInfo + ':eq(' + tableIndex + ')').addClass('highlight');
    }
}




$(document).keydown(function (e) {

    var vItemDlt = $('#Modal_ItemDlt').attr('data-modal');

    var Search_ModalOpen = $('#Modal_Item_Search').attr("data-Modal");

    var Recall_ModalOpen = $('#Modal_Recall').attr("data-Modal");

    var Free_Search_ModalOpen = $('#Modal_Free_Item_Search').attr("data-Modal");

    var Free_div = $('.free').attr("data-status");

    var tableInfo = 'mstrTable tbody tr';

    if (Search_ModalOpen === 'Open' && Free_div === 'Close') {

        tableInfo = 'table_Item_Search tbody tr';
        // alert(tableInfo);
    }

    if (Recall_ModalOpen === 'Open') {
        tableInfo = 'tbl_Recall_Item tbody tr';
    }
    if (Free_Search_ModalOpen === 'Open') {
        var vCode = $('#Modal_Free_Item_Search').attr("data-code");
        if (vCode == 'single') {
            tableInfo = 'table_Free_Item_Search tbody tr';
        } else {
            tableInfo = 'table_Free_Item_Search_master tbody tr';
        }
    }

    if (Free_div === 'Open' && Free_Search_ModalOpen === 'Close') {
        tableInfo = 'tbl_free_Item tbody tr';

    }

    switch (e.which) {
        case 38:
            //up arrow

            if (Search_ModalOpen === 'Open' || Recall_ModalOpen === 'Open' || Free_Search_ModalOpen === 'Open') {

                if (Search_ModalOpen === 'Open') {
                    highlight(tableInfo, $('#' + tableInfo + '.highlight').index() - 1);
                    $('#btn_SaleItem_ModalSearch').focus();
                }

                if (Recall_ModalOpen === 'Open') {
                    highlight(tableInfo, $('#' + tableInfo + '.highlight').index() - 1);
                    $('#btn_Recall_Submit').focus();
                }
                if (Free_Search_ModalOpen === 'Open') {
                    highlight(tableInfo, $('#' + tableInfo + '.highlight').index() - 1);
                    $('#btn_FreeItem_ModalSearch').focus();
                }
            }
            else {
                if (vItemDlt != 'Open') {
                    highlight(tableInfo, $('#' + tableInfo + '.highlight').index() - 1);
                }

            }

            break;
        case 40:

            if (Search_ModalOpen === 'Open' || Recall_ModalOpen === 'Open' || Free_Search_ModalOpen === 'Open') {

                if (Search_ModalOpen === 'Open') {
                    highlight(tableInfo, $('#' + tableInfo + '.highlight').index() + 1);
                    $('#btn_SaleItem_ModalSearch').focus();
                }
                if (Recall_ModalOpen === 'Open') {
                    highlight(tableInfo, $('#' + tableInfo + '.highlight').index() + 1);
                    $('#btn_Recall_Submit').focus();
                } if (Free_Search_ModalOpen === 'Open') {
                    highlight(tableInfo, $('#' + tableInfo + '.highlight').index() + 1);
                    $('#btn_FreeItem_ModalSearch').focus();
                }
            }
            else {
                if (vItemDlt != 'Open') {
                    highlight(tableInfo, $('#' + tableInfo + '.highlight').index() + 1);
                }
            }
            break;

    }

});