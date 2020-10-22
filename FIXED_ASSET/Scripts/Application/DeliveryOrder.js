function myFunction(id) {

    var Search_ModalOpen = $('#Modal_Item_Search').attr("data-Modal");
    if (Search_ModalOpen == "Open") {
        $('#Modal_Item_Search #table_Item_Search .highlight').each(function () {

            $('#Modal_Item_Search #table_Item_Search .highlight').removeClass('highlight');

        });

        $('#Modal_Item_Search #table_Item_Search #' + id).addClass('highlight');
    } else {
        $('#mstrTable .highlight').each(function () {

            $('#mstrTable .highlight').removeClass('highlight');

        });

        $('#mstrTable #' + id).addClass('highlight');
    }

};

function PickingNumber(vPickingNumber) {

    if (vPickingNumber !== '') {
           $.ajax({
            type: "POST",
            url: "/SalesOrder/GetPickingInfo",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(
                {
                    _Picking_No: vPickingNumber
                }
            ),
            success: function (response) {

                console.log(response.Third);



                if (response.Third.length > 0) {
                    $("#scanqty").text(0);
                    if (response.Third[0]['Picked'] != null) {
                        $("#scanqty").text(response.Third[0]['Picked']);
                    }
                    $("#Pendingqty").text(0);
                    if (response.Third[0]['Pending'] != null) {
                        $("#Pendingqty").text(response.Third[0]['Pending']);
                    }

                    $("#Orderty").text(0);
                    if (response.Third[0]['Bookqty'] != null) {
                        $("#Orderty").text(response.Third[0]['Bookqty']);
                    }
                    
                    
                    $("#OrderNumber").val(response.Third[0]['Order_No']);
                    $("#PickerName").val(response.Third[0]['Picker_Name']);
                    $("#OutletName").val(response.Third[0]['Customer_Name']);
                    $("#RequestDate").val(response.Third[0]['Order_date']);
                    $("#PickingNumber").attr("data-type", response.Third[0]['Type']);
                    $("#PickingNumber").attr("disabled", true);
                    $("#OrderNumber").attr("disabled", true);
                    $("#OutletName").attr("disabled", true);

                    $('#tbl_PickingList').empty();
                    var result = "<table id='tbl_PickingListDetails' class='table table-striped'>";
                    if (response.First.length > 0) {

                        result += "<tr  style='background: rgb(61, 168, 217);'>";
                        for (var i = 0; i < response.First.length; i++) {
                            result += "<th style='text-align: center; color: aliceblue;'>" + response.First[i].Column_Name + "</th>";
                        }
                        result += "</tr>";
                        for (var j = 0; j < response.Second.length; j++) {
                            if (response.Second[j]['Delivery Status'] === 'Pending') {
                                result += "<tr style='background: #ff6c6c5e;'>";
                                for (var l = 0; l < response.First.length; l++) {
                                    var columnName = response.First[l].Column_Name;
                                    result += "<td  style='text-align: center;border: 1px solid #d4000040;'>" + response.Second[j][columnName] + "</td>";
                                }
                                result += "</tr>";

                            } else {
                                result += "<tr style='background: #76d070;'>";
                                for (var k = 0; k < response.First.length; k++) {
                                    var columnNames = response.First[k].Column_Name;
                                    result += "<td style='text-align: center;border: 1px solid #d4000040;'>" + response.Second[j][columnNames] + "</td>";
                                }
                                result += "</tr>";
                            }

                        }
                        $("#ItemBarcode").focus();
                    }

                }
                else {
                    result += "<th>NO Data</th>";
                    result += "<td>NO Data</td>";
                    $("#PickingNumber").attr("disabled", false);
                    $("#OrderNumber").attr("disabled", false);
                    $("#OutletName").attr("disabled", false);
                    PlaySound();
                    toastr.error("Please Check This PICKING NUMBER/The Number is already used/Invalid Picking number ", "Please Check PICKING NUMBER",
                        {
                            "positionClass": "toast-top-right",
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "closeButton": true,
                            "preventDuplicates": true
                        });
                }

                result += "</table>";

                $('#tbl_PickingList').append(result);

                $('#mstrTable tr').not(function () { return !!$(this).has('th').length; }).remove();
                var result = "";

                if (response.Fourth.length > 0) {
                    for (var i = 0; i < response.Fourth.length; i++) {
                        result += "<tr onclick='myFunction(this.id)' id='" + response.Fourth[i].sBarcode + "' data-refid='" + response.Fourth[i].REF_ID + "'><td style='text-align: center;border: 1px solid #d4000040;'>" + response.Fourth[i].ARNO + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.Fourth[i].sBarcode + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.Fourth[i].COLOR + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.Fourth[i].Gender + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.Fourth[i].SIZE + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.Fourth[i].SHORTNAME + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'> " + response.Fourth[i].DELQTY + "</td>" +
                            "<td style='text-align: center;border: 1px solid #d4000040;'>" +
                            "<a href='#' id='" + response.Fourth[i].sBarcode + "' onClick='btnItemDlt()'> <i class='fa fa-trash-o'></i></a></td> </tr>";
                    }
                }

                $('#mstrTable').append(result);
                $('#tbl_VarianceList').empty();

                var result = "<table id='tbl_VarianceListDetails' class='table table-striped'>";
                console.log(response.Third.length)
                console.log(response.Fifth.length)
                if (response.Third.length > 0) {
                    if (response.Fifth.length > 0) {
                        result += "<tr  style='background: rgb(61, 168, 217);'>";
                        for (var i = 0; i < response.Fifth.length; i++) {
                            result += "<th style='text-align: center;color: aliceblue;'>" + response.Fifth[i].Column_Name + "</th>";
                        }
                        result += "</tr>";
                        for (var j = 0; j < response.sixth.length; j++) {
                            result += "<tr style='background: #93cfdc;'>";
                            for (var k = 0; k < response.Fifth.length; k++) {
                                var columnNames = response.Fifth[k].Column_Name;
                                result += "<td  style='text-align: center;border: 1px solid #d4000040;'>" + response.sixth[j][columnNames] + "</td>";
                            }
                            result += "</tr>";
                        }
                        $('#btnSave').attr("data-hasVariant", true);
                    } else {
                        $('#btnSave').attr("data-hasVariant", false);
                        result += "<th>NO Variant</th>";
                        result += "<td>NO Variant</td>";
                    }

                }
                else {
                    result += "<th>NO Data</th>";
                    result += "<td>NO Data</td>";


                }
                result += "</table>";
                $('#tbl_VarianceList').append(result);
            },

            failure: function (response) {

                location.reload();
            },
            error: function (response) {

                location.reload();
            }
        });
    }
}


$('#PickingNumber').keypress(function (e) {

    var code = e.keyCode;
    if (code === 13) {

        var vPickingNumber = $('#PickingNumber').val();
        PickingNumber(vPickingNumber);
    }
});

function ScanAddSingleBarcode() {

    var vQuantity = $('#Item_Quantity').val();
    var vRefID = $('#Item_Quantity').attr('data-ref_id');
    var vart_code = $('#Item_Quantity').attr('data-art_code');
    var vARTNO = $('#Item_Quantity').attr('data-ARTNO');
    var vtyp = $('#PickingNumber').attr('data-type');

    if (vQuantity.length === 0) {
        vQuantity = 0;
    }
    var vBarcode = $('#ItemBarcode').val();


    if (vQuantity === 0) {
        PlaySound();
        toastr.error("Please Check item quantity", "Please enter item quantity greater than 0",
            {
                "positionClass": "toast-top-right",
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "closeButton": true,
                "preventDuplicates": true
            });
        e.preventDefault();
        return;
    }
    else {
        if (vBarcode == "") {
            PlaySound();
            toastr.error("Please Give Barcode", "Please enter Currect Barcode",
                {
                    "positionClass": "toast-top-right",
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "closeButton": true,
                    "preventDuplicates": true
                });
            return;
        }
        $.ajax({
            type: "POST",
            url: "/SalesOrder/QtyCheck",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(
                {
                    _Quantity: vQuantity,
                    _Barcode: vBarcode
                }
            ),
            success: function (response) {

                if (response[0].Result === 1) {
                    $('#Details').show();
                    $('#BarcodeInfo').hide();


                    AddSingleBarcode(vBarcode, vQuantity, vRefID, vart_code, vARTNO, vtyp);
                }
                else {
                    PlaySound();
                    toastr.error("Please Check Barcode And Order quantity", "Please Check Barcode And Order quantity",
                        {
                            "positionClass": "toast-top-right",
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "closeButton": true,
                            "preventDuplicates": true
                        });
                    $('#Details').hide();
                    $('#BarcodeInfo').show();
                    //  e.preventDefault();
                    return;
                }
                $('#ItemBarcode').val("");
                $('#ItemBarcode').focus();

            },
            failure: function (response) {

                location.reload();
            },
            error: function (response) {

                location.reload();
            }
        });


    }
    $("#Item_Quantity").val('1');

}



$('#Item_Quantity').keypress(function (e) {

    var code = e.keyCode;
    if (code === 13) {
        ScanAddSingleBarcode();
    }
});

function AddSingleBarcode(vBarcode, vQuantity, vRefID, vart_code, vARTNO, vtyp) {

    $.ajax({
        type: "POST",
        url: "/SalesOrder/Barcode_Entry",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                _Quantity: vQuantity,
                _RefID: vRefID,
                _Art_code: vart_code,
                _sBarcode: vBarcode,
                _ARTNO: vARTNO,
                _typ: vtyp
            }
        ),
        success: function (response) {

            if (response.Second) {
                if (response.First) {
                    var vPickingNumber = $('#PickingNumber').val();
                    PickingNumber(vPickingNumber);
                }
                else {
                    PlaySound();
                    toastr.error("Please Check Barcode", "Error!! Please Check Barcode",
                        {
                            "positionClass": "toast-top-right",
                            "showDuration": "300",
                            "hideDuration": "1000",
                            "timeOut": "5000",
                            "closeButton": true,
                            "preventDuplicates": true
                        });
                }
            } else {
                alert("Session Expired.!! Please Login Again.");
                location.reload();
            }


        },
        failure: function (response) {
            PlaySound();
            toastr.error("Error!!", "Error!! Failure Occurred",
                {
                    "positionClass": "toast-top-right",
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "closeButton": true,
                    "preventDuplicates": true
                });
            alert(response.responseText);
        },
        error: function (response) {

            // location.reload();
            PlaySound();
            toastr.error("Error!!", "Error!! Occurred",
                {
                    "positionClass": "toast-top-right",
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "closeButton": true,
                    "preventDuplicates": true
                });
            alert(response.responseText);
        }
    });
}






function Barcode_Item_Search() {
    var vSearch = $('#Modal_Item_Search #Item_Search').val();
    $.ajax({
        type: "POST",
        url: "/SalesOrder/Item_Search",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                _Search: vSearch
            }
        ),
        success: function (response) {
            $('#Modal_Item_Search #tbl_Modal_ItemSearch').empty();

            var result = "";
            if (response.length > 0) {


                for (var i = 0; i < response.length; i++) {
                    result += "<tr onclick='myFunction(this.id)' id='" + response[i].BARCODE + "'><td style='text-align:center;'>" + response[i].ARNO + "</td>" +
                        "<td style='text-align:center;'> " + response[i].BARCODE + "</td>" +
                        "<td style='text-align:center;'> " + response[i].SHORTNAME + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Size + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Color + "</td>" +
                        "<td style='text-align:center;'> " + response[i].Gender + "</td>"
                        ;
                    // "<td> <i class='glyphicon glyphicon-trash' onclick='delete_this(" + response[i].Barcode + ")'></i></td>";
                }
            }
            else {
                result += "<tr><td colspan='7' style='text-align:center;'>NO RESULT FOUND </td></tr>";
            }

            $('#Modal_Item_Search #tbl_Modal_ItemSearch').append(result);

        },

        failure: function (response) {

            // location.reload();
        },
        error: function (response) {

            //location.reload();
        }
    });



}


$('#IsMaster').change(function () {

    $('#ItemBarcode').val('');
    $('#ItemMasterBarcode').val('');
    $('#Details').show();
    $('#MBarcodeInfo').hide();
    $('#BarcodeInfo').hide();

    if ($(this).is(":checked")) {

        swal({
            title: 'Are you sure this is master barcode??',
            text: "You will be able to revert this!!",
            type: 'warning',
            showCancelButton: false,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Sucessfull!'
        }).then((result) => {
            if (result.value) {
                $('#Scan_Master').show();
                $('#Scan_Single').hide();

            }
        })

    }
    else {

        $('#Scan_Single').show();
        $('#Scan_Master').hide();
        $('#MBarcodeInfo').hide();
    }

});

function Modal_Item_Search() {
    $("#Modal_Item_Search").modal("show");
}

function Item_Barcode(vBarcode) {
    ///////

    $.ajax({
        type: "POST",
        url: "/SalesOrder/Item_Search_DL",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                _Search: vBarcode
            }
        ),
        success: function (response) {

            if (response.length === 1) {

                $('#Details').hide();
                $('#BarcodeInfo').show();
                $('#Item_Quantity').focus();
                $('#Article_No').html(response[0]['ARNO']);
                $('#ORDER_QUTY').html(response[0]['ORDQty']);
                $('#DELEVER_QUTY').html(response[0]['Delqty']);

                $('#Item_Quantity').attr("data-ART_CODE", response[0]['ART_CODE']);
                $('#Item_Quantity').attr("data-Ref_ID", response[0]['Ref_ID']);
                $('#Item_Quantity').attr("data-ARTNO", response[0]['ARTNO']);
                ScanAddSingleBarcode();

            } else {

                Modal_Item_Search();
                $('#Details').show();
                $('#BarcodeInfo').hide();
            }
        },
        failure: function (response) {

        },
        error: function (response) {

        }
    });
}

$('#ItemBarcode').keypress(function (e) {

    var code = e.keyCode;

    var vBarcode = $('#ItemBarcode').val();
    if (code === 13) {
       
        Item_Barcode(vBarcode);

    }
});


$('#ItemMasterBarcode').keypress(function (e) {

    var code = e.keyCode;

    var vMBarcode = $('#ItemMasterBarcode').val();
    if (code === 13) {

        AddMasterBarcode();
      //  Item_Master_Barcode(vMBarcode, 1);

    }
});

$('#Master_Quantity').keypress(function (e) {

    var code = e.keyCode;
    var vQuantity = $('#Master_Quantity').val();
    if (vQuantity.length === 0) {
        vQuantity = 0;
    }
    var vBarcode = $('#ItemMasterBarcode').val();
    if (code === 13) {

        if (vQuantity === 0) {
            PlaySound();
            toastr.error("Please Check item quantity", "Please enter item quantity greater than 0",
                {
                    "positionClass": "toast-top-right",
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "closeButton": true,
                    "preventDuplicates": true
                });
            e.preventDefault();
            return;
        }
        else {
           

            var vMBarcode = $('#ItemMasterBarcode').val();
            AddMasterBarcode();
          //  GetMasterBarcodeInfo(vMBarcode, vQuantity);
        }

    }
});


function Item_Master_Barcode(vMBarcode, vqty) {

    GetMasterBarcodeInfo(vMBarcode, vqty);
}

function GetMasterBarcodeInfo(vMBarcode, vqty) {
    $('#Details').hide();
    $('#BarcodeInfo').hide();
    $('#Master_Quantity').focus();
    $('#MBarcodeInfo').show();
    $(".overlay").show();

    $.ajax({
        type: "POST",
        url: "/SalesOrder/MBarcodeInfo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(
            {
                _MBarcode: vMBarcode,
                _qty: vqty
            }
        ),
        success: function (response) {
            $('#size_details').remove();
            //console.log(response.Second.length);

            if (response.Second.length > 0) {
                var result = "<table  id='size_details' class='table table-striped'><tr>";

                for (var i = 1; i < response.Second.length; i++) {

                    result += "  <th style='text-align: center;'>" + response.Second[i].Column_Name + "</th>";
                    var sizeid = [];
                    for (var x = 1; x < response.Second.length - 1; x++) {

                        sizeid.push(response.Second[x].Column_Name);
                    }
                }

                result += "</tr>";
                for (var j = 0; j < response.Third.length; j++) {
                    result += "<tr>";
                    for (var k = 1; k < response.Second.length; k++) {

                        var columnName = response.Second[k].Column_Name;
                        result += "<td style='text-align: center;' data-size=" + response.Second[k].Column_Name + " id= detailqty_" + response.Second[k].Column_Name + ">" + response.Third[j][columnName] + "</td>";

                    }
                    result += "</tr>";

                }
                result += "</tr></table>";


                $('#tbl_MasterDetails').append(result);
                $(".overlay").hide();
                $("#btn_Addart").focus();
            }
            else {
                PlaySound();
                toastr.error("Error!!", "Please Check Your Barcode!!",
                    {
                        "positionClass": "toast-top-right",
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "closeButton": true,
                        "preventDuplicates": true
                    });
                $("#ItemMasterBarcode").focus();
            }

        },


        failure: function (response) {

            alert(response.responseText);

        },
        error: function (response) {

            alert(response.responseText);
        }
    });
}

function Btn_Back() {
    $('#Details').show();
    $('#MBarcodeInfo').hide();
    $('#BarcodeInfo').hide();
    
}
function AddMasterBarcode() {
    //This is comment for this time
  //  var vqty = $('#Master_Quantity').val();
    var vqty = 1;

    var vMBarcode = $('#ItemMasterBarcode').val();
    var vType = $('#PickingNumber').attr("data-type");


    $.ajax({
        type: "POST",
        url: "/SalesOrder/MBarcodeSTKCHK",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(
            {
                _MBarcode: vMBarcode,
                _qty: vqty,
                _Type: vType
            }
        ),
        success: function (response) {

            if (response) {

                if (vType == "SO") {
                    vType = "SM";
                } else {
                    vType = "TM";
                }
               
                var vRefID = $('#PickingNumber').val();
               
                AddSingleBarcode(vMBarcode, vqty, vRefID, 0, '', vType);

                $('#Details').show();
                $('#BarcodeInfo').hide();
                $('#MBarcodeInfo').hide();
                $('#ItemMasterBarcode').val("");
                $('#ItemMasterBarcode').focus();


            } else {
                PlaySound();
                toastr.error("Please Check Pick Quantity and Delivered Quantity!!!  ", " ERROR !!!",
                    {
                        "positionClass": "toast-top-right",
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "closeButton": true,
                        "preventDuplicates": true
                    });

            }
        },


        failure: function (response) {

            alert(response.responseText);

        },
        error: function (response) {

            alert(response.responseText);

        }
    });

}

$('#Modal_Item_Search').on('shown.bs.modal', function (e) {

    $('#table_Item_Search tr').not(function () { return !!$(this).has('th').length; }).remove();
    $('#Modal_Item_Search').attr('data-modal', 'Open');
    $('#Modal_Item_Search #Item_Search').val($('#ItemBarcode').val());
    $('#Modal_Item_Search #Item_Search').focus();
    Barcode_Item_Search();


});

$('#Modal_Item_Search').on('hidden.bs.modal', function (e) {

    $('#table_Item_Search tr').not(function () { return !!$(this).has('th').length; }).remove();
    $('#Modal_Item_Search').attr('data-modal', 'Close');
});


$('#Modal_Item_Search #Item_Search').keyup(function (e) {

    var vItem = $('#Item_Search').val();


    switch (e.keyCode) {
        case 38: {//up arrow
            if (vItem !== undefined) {
                $('#Modal_Item_Search #Item_Search').blur();
                $('#btn_SaleItem_ModalSearch').focus();
            } else {
                $('#Item_Search').focus();
            }

            return;

        }
        case 40: {//down arrow
            if (vItem !== undefined) {
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

function btn_SaleItem_ModalSearch() {

    var vBarcode = $('#Modal_Item_Search table#table_Item_Search tr.highlight').attr('id');
    $('#ItemBarcode').val(vBarcode);
    $("#Modal_Item_Search").modal("hide");
    Item_Barcode(vBarcode);
}

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

    //var ModalOpen = $('#Modal_Item_Search').data('Modal'); //getter
    var Search_ModalOpen = $('#Modal_Item_Search').attr("data-Modal");

    var tableInfo = 'mstrTable tbody tr';
    if (Search_ModalOpen === 'Open') {
        tableInfo = 'table_Item_Search tbody tr';
    }



    switch (e.which) {
        case 38:
            //up arrow
            //  alert(Search_ModalOpen);
            if (Search_ModalOpen === 'Open') {
                if (Search_ModalOpen === 'Open') {
                    highlight(tableInfo, $('#' + tableInfo + '.highlight').index() - 1);
                }

            }

            else {
                highlight(tableInfo, $('#' + tableInfo + '.highlight').index() - 1);
            }
            break;
        case 40:
            if (Search_ModalOpen === 'Open') {
                if (Search_ModalOpen === 'Open') {
                    highlight(tableInfo, $('#' + tableInfo + '.highlight').index() + 1);
                }

            } else {
                highlight(tableInfo, $('#' + tableInfo + '.highlight').index() + 1);
            }

            break;
    }

});

function Save_Click() {


    var vHasVariant = $('#btnSave').attr("data-hasvariant");

    if (vHasVariant != 'false') {

        $("#Modal_SaveValidation").modal("show");

        return;

    } else {

        FinalSave();
    }
}

function FinalSave() {
    var vPickingNumber = $('#PickingNumber').val();
    var vType = $('#PickingNumber').attr("data-type");

    $.ajax({

        type: "POST",
        url: "/SalesOrder/Save_Click",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                _Order_no: vPickingNumber,
                _Type: vType
            }
        ),

        success: function (response) {
            if (response) {
                toastr.success("SAVE Sucessfully  !!! ", "Delivery Order SAVE Sucessfully  !!! ",
                    {
                        "positionClass": "toast-top-right",
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "closeButton": true,
                        "preventDuplicates": true
                    });
                setTimeout(function () { location.reload();; }, 2000);
            }
        },
        failure: function (response) {
            // location.reload();
        },
        error: function (response) {
            // location.reload();
        }
    });
}

function btnItemDlt() {

    var vBarcode = $('#mstrTable tr.highlight').attr('id');
    var vrefid = $('#mstrTable tr.highlight').attr('data-refid');

    if (vBarcode !== undefined) {
        $("#item_barcode").html(vBarcode);
        $("#btn_item_barcode").val(vBarcode);
        $('#btn_item_barcode').attr("data-refid", vrefid);
        $("#Modal_ItemDlt").modal("show");
    }
};

$('#btn_item_barcode').click(function (e) {

    var vBarcode = $(this).attr("value");
    var vRefid = $('#btn_item_barcode').attr("data-refid");
 
    var vType = $('#PickingNumber').attr("data-type");
    $.ajax({
        type: "POST",
        url: "/SalesOrder/Barcode_Clear",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(
            {
                _Barcode: vBarcode,
                _REFID: vRefid,
                _Typ: vType
            }
        ),
        success: function (response) {
            $("#Modal_ItemDlt").modal("hide");
            if (response) {
                PlaySound();
                $('table#mstrTable tr#' + vBarcode).remove();
             
                var vPickingNumber = $('#PickingNumber').val();
                PickingNumber(vPickingNumber);
            } else {
               
                var vPickingNumber = $('#PickingNumber').val();
                PickingNumber(vPickingNumber);
            }
            
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
  
});

function keyPress(e) {

    var keyCode = e.keyCode;
    switch (keyCode) {
        case 46:
            btnItemDlt();
            break;
    }
}

function LoadReport() {

    var url = '../../Report/ViewChallan.aspx';

    $("#ReportFrame").attr("src", url);

}

function Back_Click() {
    Cancle_Click();
    location.reload();
}

function Cancle_Click() {

    $.ajax({
        url: '/SalesOrder/Cancle_Click',
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {

            if (response) {
                $("#PickingNumber").val("");
                $("#PickingNumber").attr("disabled", false);
                $("#OrderNumber").attr("disabled", false);
                $("#OutletName").attr("disabled", false);
                var vPickingNumber = $('#PickingNumber').val();
                PickingNumber(vPickingNumber);

                toastr.success("Cancle Sucessfully", " Cancle Sucessfully  !!! ",
                    {
                        "positionClass": "toast-top-right",
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "closeButton": true,
                        "preventDuplicates": true
                    });
                setTimeout(function () {
                    location.reload();
                }, 2000);
            }
        },

        failure: function (response) {

            e.preventDefault();
        },
        error: function (response) {

            e.preventDefault();
        }
    });

}