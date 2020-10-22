
$(document).ready(function () {
    // $('body').addClass('sidebar-collapse');
    document.addEventListener("keydown", keyPress, false);
    $('.select2').select2();
    $('#span_ChangeAmount').hide();
    $('#PayNet_Amount').focus();
    // $('#table_Complete_Transection').hide();
    $('#msgGiftVoucher').hide();
    $('#btn_Cash_Close').hide();
    //ChannelList();
});

function keyPress(e) {
    var keyCode = e.keyCode;
    var vModal_AddCustomer = $('#Modal_AddCustomer').attr("data-Modal"),
        vModal_Card = $('#Modal_Card').attr("data-Modal"),
        vModal_MobileBanking = $('#Modal_MobileBanking').attr("data-modal"),
        vModal_Cheque = $('#Modal_Cheque').attr("data-Modal"),
        vModal_Coupon = $('#Modal_Coupon').attr("data-Modal"),
        vModal_Point_Redeem = $('#Modal_Point_Redeem').attr("data-Modal"),
        vModal_CreditNote = $('#Modal_CreditNote').attr("data-Modal");
    var vModal_FinalPosting_Done = $('#Modal_FinalPosting_Done').attr("data-Modal");

    var vbalance = $('#Balance').val();

    switch (keyCode) {
        case 27:

            if (vModal_AddCustomer === 'Open' || vModal_Card === 'Open' || vModal_MobileBanking === 'Open' || vModal_Cheque === 'Open'
                || vModal_Coupon === 'Open' || vModal_Point_Redeem === 'Open' || vModal_CreditNote === 'Open') {
                vModal_AddCustomer === 'Open' ? $("#Modal_AddCustomer").modal("hide") : "";
                vModal_Card === 'Open' ? $("#Modal_Card").modal("hide") : "";
                vModal_MobileBanking === 'Open' ? $("#Modal_MobileBanking").modal("hide") : "";
                vModal_Cheque === 'Open' ? $("#Modal_Cheque").modal("hide") : "";
                vModal_Coupon === 'Open' ? $("#Modal_Coupon").modal("hide") : "";
                vModal_Point_Redeem === 'Open' ? $("#Modal_Point_Redeem").modal("hide") : "";
                vModal_CreditNote === 'Open' ? $("#Modal_CreditNote").modal("hide") : "";
            }
            else {

                BackToSale();
            }
            break;
        case 113:
            //F2 Press

            if (typeof vbalance === 'undefined') {

                $("#Modal_Card").modal("show");

            }
            else if (parseInt(vbalance) === 0) {

            }
            else {
                $("#Modal_Card").modal("show");
            }

            break;
        case 115:
            //F4


            if (typeof vbalance === 'undefined') {

                $("#Modal_MobileBanking").modal("show");

            }
            else if (parseInt(vbalance) === 0) {

            }
            else {
                $("#Modal_MobileBanking").modal("show");
            }


            break;
        case 118:
            //F7
            if (typeof vbalance === 'undefined') {

                $("#Modal_CreditNote").modal("show");

            }
            else if (parseInt(vbalance) === 0) {

            }
            else {
                $("#Modal_CreditNote").modal("show");
            }

            break;
        case 13:
            //Enter Press
            // alert("Enter Press");
            if (vModal_FinalPosting_Done === 'Open') {

                DirectPrint();
            } else {

                // alert(vbalance);
                if (parseInt(vbalance) === 0) {
                    var _Posting = $("#btnComplete_Transection").hasClass("disabled").toString();// $("#btnComplete_Transection").attr('class');
                    if (_Posting == "true") {
                        return;
                    }
                    else {
                        Final_Posting();


                    }

                }
            }
            break;
        default:
            break;

    }

}

function BackToSale() {

    location.replace("/Channel/SingleBarcode/");
}

$("#BacktoSale").click(function (e) {
    BackToSale();
});

$(function () {
    $('#PayNet_Amount').keypress(function (e) {
        var code = e.keyCode;//? e.keyCode : e.which;
        if (code === 13) {
            Total_Balance_Calucation('CASH');
        }
    });


    // #region  [ btn Card //// btn_CardInfo_Submit]
    $("#btnCard").click(function (e) {
        $("#Modal_Card").modal("show");
    });



    $('#Modal_Card').on('shown.bs.modal', function (e) {
        // alert();
        ////////////

        $("#Modal_CreditNote").modal("hide");
        $("#Modal_MobileBanking").modal("hide");
        ///////////////////////

        var vAmount = $('#PayNet_Amount').val();
        $('#Card_Amount').val(vAmount);
        $('#Modal_Card').attr('data-modal', 'Open');
        $('#CardType').focus();

        $('#Card_No').val('');



        $.ajax({
            url: '/Sales/Tender_List',
            type: 'POST',
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(
                {
                    _Tender_TypeID: 1// 1 For Card

                }
            ),
            dataType: "json",
            success: function (response) {

                if (response.length > 0) {
                    $('select#CardType').html('');
                    // alert("Done");
                    //  console.log(response);
                    var result = '';
                    result += "<option value='0'>Select One</option>";
                    for (var i = 0; response.length > i; i++) {

                        result += "<option id='" + response[i].Tender_ID + "' value='" + response[i].Tender_ID + "'>" + response[i].Tender_Name + "</option>";
                    }
                    $('select#CardType').append(result);
                }
            }
        });

    });

    $("#CardType").change(function () {
        // alert();
        var vTender_ID = $('option:selected', this).val();
        // alert($('option:selected', this).val());


        $.ajax({
            url: '/Sales/Trxn_TenderBank_List',
            type: 'POST',
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(
                {
                    _Tender_ID: vTender_ID// 1 For Card

                }
            ),
            dataType: "json",
            success: function (response) {

                if (response.length > 0) {
                    $('select#CardBank_Name').html('');
                    // alert("Done");
                    //  console.log(response);
                    var result = '';
                    result += "<option value='0'>Select One</option>";
                    for (var i = 0; response.length > i; i++) {

                        result += "<option id='" + response[i].Bank_ID + "' value='" + response[i].Bank_ID + "'>" + response[i].Bank_Name + "</option>";
                    }
                    $('select#CardBank_Name').append(result);
                }

                $("#CardBank_Name").focus();
            }
        });
    });


    $("#CardBank_Name").change(function () {

        $("#Card_No").focus();
    });


    $('#Modal_Card').keyup(function (e) {
        if (e.keyCode === 13) {
            btn_CardInfo_Submit();
        }
    });
    // #endregion
});






function btn_CardInfo_Submit() {

    var vCardType = $('#CardType').val();
    var vCardBank_Name = $('#CardBank_Name').val();
    var vCard_No = $('#Card_No').val();

    if (vCardType === '0') {
        PlaySound();
        toastr.error("Please Select Card Type !!! ", "Please Select Card Type and  TRY AGAIN ",
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
    if (vCardBank_Name === '0') {
        PlaySound();
        toastr.error("Please Select Bank Name ", "Select Bank Name  and TRY AGAIN ",
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
    if (vCard_No === '') {
        PlaySound();
        toastr.error("Please Provide Card Last 4 Digit and TRY AGAIN ", "Please Provide Card Last 4 Digit",
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

    var vPayNet_Amount = $('#Card_Amount').val(),
        _Net_Amount = $('#Net_Amount').val(),
        _Balance = $('#Balance').val();

    if (typeof _Balance != 'undefined') {
        //   alert(_Balance);
        //   alert("Yse" + vPayNet_Amount + "//" + _Net_Amount)

        if (parseInt(vPayNet_Amount) > parseInt(_Balance)) {
            PlaySound();
            toastr.error("MAXIMUM Payment Exceeded .Plaeas TRY AGAIN ", "MAXIMUM Payment Exceeded",
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
    }
    else {
        //  alert(_Net_Amount + "/_____<________/" + vPayNet_Amount);
        if (parseInt(_Net_Amount) < parseInt(vPayNet_Amount)) {
            PlaySound();
            toastr.error("MAXIMUM Payment Exceeded .Plaeas TRY AGAIN ", "MAXIMUM Payment Exceeded",
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

    }

    Total_Balance_Calucation("CARD");
}

//#region  [btn_MobileBankingInfo_Submit() ]
$("#btnMobileBanking").click(function (e) {
    $("#Modal_MobileBanking").modal("show");
});

$('#Modal_MobileBanking').on('shown.bs.modal', function (e) {
    $("#Modal_Card").modal("hide");
    $("#Modal_CreditNote").modal("hide");

    //////////////////////////////////////
    var vAmount = $('#PayNet_Amount').val();
    // alert(asd);
    $('#Mobile_Amount').val(vAmount);
    $('#Modal_MobileBanking').attr('data-modal', 'Open');

    $('#BankingType').focus();

    $.ajax({
        url: '/Sales/Tender_List',
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(
            {
                _Tender_TypeID: 2// 1 For Card

            }
        ),
        dataType: "json",
        success: function (response) {

            if (response.length > 0) {
                $('select#BankingType').html('');

                var result = '';
                result += "<option value='0'>Select One</option>";
                for (var i = 0; response.length > i; i++) {

                    result += "<option id='" + response[i].Tender_ID + "' value='" + response[i].Tender_ID + "'>" + response[i].Tender_Name + "</option>";
                }
                $('select#BankingType').append(result);
            }
        }
    });
});


$('#Modal_MobileBanking').on('hidden.bs.modal', function (e) {

    $('#Modal_MobileBanking').attr('data-modal', 'Close');
    $('#PayNet_Amount').focus();

});


$('#Modal_AddCustomer').on('shown.bs.modal', function (e) {
    $('#Mobile_No').focus();
    $('#Modal_AddCustomer').attr('data-modal', 'Open');

});

$('#Modal_AddCustomer').on('hidden.bs.modal', function (e) {

    $('#Modal_AddCustomer').attr('data-modal', 'Close');
    $('#PayNet_Amount').focus();

});

$('#Modal_Card').on('hidden.bs.modal', function (e) {

    $('#Modal_Card').attr('data-modal', 'Close');
    $('#PayNet_Amount').focus();

});

$('#Modal_Coupon').on('hidden.bs.modal', function (e) {

    $('#Modal_Coupon').attr('data-modal', 'Close');
    $('#PayNet_Amount').focus();

});
$('#Modal_Coupon').on('shown.bs.modal', function (e) {
    $('#Modal_Coupon').attr('data-modal', 'Open');
});

$('#Modal_Point_Redeem').on('hidden.bs.modal', function (e) {

    $('#Modal_Point_Redeem').attr('data-modal', 'Close');
    $('#PayNet_Amount').focus();

});
$('#Modal_Point_Redeem').on('shown.bs.modal', function (e) {
    $('#Modal_Point_Redeem').attr('data-modal', 'Open');
});


function btn_MobileBankingInfo_Submit() {

    var vBankingType = $('#BankingType').val();
    var vMB_Mobile_No = $('#MB_Mobile_No').val();
    var vMB_Transection_No = $('#MB_Transection_No').val();

    if (vBankingType === '0') {
        PlaySound();
        toastr.error("Please Select Banking  Type !!! ", "Please Select Banking Type and  TRY AGAIN ",
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
    if (vMB_Mobile_No === '') {
        PlaySound();
        toastr.error("Please Give Mobile Number ", "Please Give Mobile Number And TRY AGAIN ",
            {
                "positionClass": "toast-top-right",
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "closeButton": true,
                "preventDuplicates": true
            });
        return false;
    }
    if (vMB_Transection_No === '') {
        PlaySound();
        toastr.error("Please Give Transection Number ", "Please Give Transection Number And TRY AGAIN ",
            {
                "positionClass": "toast-top-right",
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "closeButton": true,
                "preventDuplicates": true
            });
        return false;
    }


    var vPayNet_Amount = $('#Mobile_Amount').val(),
        _Net_Amount = $('#Net_Amount').val(),
        _Balance = $('#Balance').val();

    if (typeof _Balance != 'undefined') {
        if (parseInt(vPayNet_Amount) > parseInt(_Balance)) {
            PlaySound();
            toastr.error("MAXIMUM Payment Exceeded .Plaeas TRY AGAIN ", "MAXIMUM Payment Exceeded",
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
    }
    else {

        if (parseInt(_Net_Amount) < parseInt(vPayNet_Amount)) {
            PlaySound();
            toastr.error("MAXIMUM Payment Exceeded .Plaeas TRY AGAIN ", "MAXIMUM Payment Exceeded",
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
    }


    Total_Balance_Calucation("MOBILE_BANKING");

}

$('#Modal_MobileBanking').keyup(function (e) {
    if (e.keyCode === 13) {
        btn_MobileBankingInfo_Submit();
    }
});

$("#BankingType").change(function () {

    $("#MB_Mobile_No").focus();
});
$("#MB_Mobile_No").change(function () {

    $("#MB_Transection_No").focus();
});

//#endregion


$('#Modal_CreditNote').on('shown.bs.modal', function (e) {
    /////////////////////////
    $("#Modal_MobileBanking").modal("hide");
    $("#Modal_Card").modal("hide");
    ///////////////////////
    $('#Modal_CreditNote').attr('data-modal', 'Open');
    Credit_Note_Load();
    $('#Credit_Note_No').focus();
});



$('#Modal_CreditNote').on('hidden.bs.modal', function (e) {
    $('#Modal_CreditNote').attr('data-modal', 'Close');
    $('#PayNet_Amount').focus();
});
$("#btnCreditNote").click(function (e) {
    $("#Modal_CreditNote").modal("show");
});


function btn_CreditNote_Submit() {

    var _Credit_Note_Amount = $('#Credit_Note_Amount').val();
    _Net_Amount = $('#Net_Amount').val();

    _Balance = $('#Balance').val();

    if (typeof _Credit_Note_Amount != 'undefined') {
        _Credit_Note_Amount = $('#Credit_Note_Amount').val();
    } else {
        _Credit_Note_Amount = 0;
    }
    if (typeof _Net_Amount != 'undefined') {
        _Net_Amount = $('#Net_Amount').val();
    } else {
        _Net_Amount = 0;
    } if (typeof _Balance != 'undefined') {
        _Balance = $('#Balance').val();
    } else {
        _Balance = 0;
    }

    if (parseInt(_Net_Amount) >= parseInt(_Credit_Note_Amount) || parseInt(_Balance) >= parseInt(_Credit_Note_Amount)) {

        Total_Balance_Calucation("CREDIT_NOTE");
    } else {
        PlaySound();
        toastr.error("Please add more Item ", "Please add More Item And TRY AGAIN ",
            {
                "positionClass": "toast-top-right",
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "closeButton": true
            });
        return false;

    }
}

$('#Modal_CreditNote').keyup(function (e) {
    if (e.keyCode === 13) {
        btn_CreditNote_Submit();
    }
});


function btn_CouponInfo_Submit() {
    var vCouponType = $('#CouponType').val();
    if (vCouponType === 'Gift Voucher') {
        Total_Balance_Calucation("GIFT_VOUCHER");
    }
    else {
        Total_Balance_Calucation("COUPON");
    }

};

$('#Modal_Coupon').keyup(function (e) {
    if (e.keyCode === 13) {
        btn_CouponInfo_Submit();
    }
});

//#endregion 
//#region  [ btn_CouponInfo_Submit()]

$("#btnCheque").click(function (e) {
    $("#Modal_Cheque").modal("show");

});

$('#Modal_Cheque').on('show.bs.modal', function (e) {
    var vAmount = $('#PayNet_Amount').val();
    // alert(asd);
    $('#Cheque_Amount').val(vAmount);
    $('#Modal_Cheque').attr('data-modal', 'Open');
});
$('#Modal_Cheque').on('hidden.bs.modal', function (e) {

    $('#Modal_Cheque').attr('data-modal', 'Close');
    $('#PayNet_Amount').focus();
});


//#endregion 
$('#btnPoint_Redeem').click(function (e) {
    $('#Modal_Point_Redeem').modal("show");

});
//#region [Cash Button Click]

$('#btnCash').click(function (e) {
    Total_Balance_Calucation('CASH');
});
//#endregion 
function Total_Balance_Calucation(TenderType) {
    var vPayNet_Amount;
    var vNet_Amount = $('#Net_Amount').val();
    var vBalance,
        TotalCash, vCash_Amount;// TotalCardAmount = 0,

    switch (TenderType) {
        case "CASH":
            // = parseInt(vNet_Amount) - parseInt(vPayNet_Amount);
            vPayNet_Amount = $('#PayNet_Amount').val();
            vCash_Amount = $('#Cash_Amount').val();
            var vCurrentBalance;
            if (typeof vCash_Amount !== 'undefined') {

                TotalCash = parseInt(vCash_Amount) + parseInt(Math.abs(vPayNet_Amount));
                vCurrentBalance = parseInt(vNet_Amount) - parseInt(TotalCash);
                AddCashRow(TotalCash);

                var TotalCardAmount = 0,
                    TotalCashAmount = 0,
                    TotalMobileAmount = 0,
                    TotalGiftAmount = 0,
                    TotalCredit_NoteAmount = 0,
                    Card_Amount = document.querySelectorAll('.Card_Amount'),
                    MobileAmount = document.querySelectorAll('.Mobile_Amount'), i,
                    Credit_Note = $('#Credit_Note').val();

                for (i = 0; i < Card_Amount.length; i++) {
                    TotalCardAmount += parseFloat(Card_Amount[i].value || 0);
                }
                for (i = 0; i < MobileAmount.length; i++) {
                    TotalMobileAmount += parseFloat(MobileAmount[i].value || 0);
                }

                if (typeof vCash_Amount !== 'undefined') {
                    TotalCashAmount = $('#Cash_Amount').val();
                }
                if (typeof vGIFT_VOUCHER !== 'undefined') {
                    TotalGiftAmount = $('#GIFT_VOUCHER').val();
                }
                if (typeof Credit_Note != 'undefined') {
                    TotalCredit_NoteAmount = $('#Credit_Note').val();
                }
                //Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) 
                var Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) + parseInt(TotalGiftAmount) + parseInt(TotalCredit_NoteAmount);
                vCurrentBalance = parseInt(vNet_Amount) - parseInt(Total);
                vBalance = Math.abs(vCurrentBalance);

                if (vCurrentBalance <= 0) {

                    vCurrentBalance = 0;
                    $('#PayNet_Amount').prop('disabled', true);
                    $('#span_Pay').hide();


                    $('#span_Point').hide();
                    $('#span_ChangeAmount').show();
                    $('#table_PayButton').hide();
                    // $('#table_Complete_Transection').show();

                }

                AddBalanceRow(vCurrentBalance, vBalance);
            }
            else {
                AddCashRow(Math.abs(vPayNet_Amount));
                TotalCash = parseInt(Math.abs(vPayNet_Amount));

                if (TotalCash > vNet_Amount) {
                    vCurrentBalance = parseInt(TotalCash) - parseInt(vNet_Amount);//6000-5500=500


                    TotalCardAmount = 0,
                        TotalCashAmount = 0,
                        TotalMobileAmount = 0,
                        TotalGiftAmount = 0,
                        TotalCredit_NoteAmount = 0,
                        Card_Amount = document.querySelectorAll('.Card_Amount'),
                        MobileAmount = document.querySelectorAll('.Mobile_Amount'), i,
                        Credit_Note = $('#Credit_Note').val();

                    for (i = 0; i < Card_Amount.length; i++) {
                        TotalCardAmount += parseFloat(Card_Amount[i].value || 0);
                    }
                    for (i = 0; i < MobileAmount.length; i++) {
                        TotalMobileAmount += parseFloat(MobileAmount[i].value || 0);
                    }
                    // if (typeof vCash_Amount != 'undefined') {
                    if ($('#Cash_Amount').val() !== undefined) {
                        TotalCashAmount = $('#Cash_Amount').val();
                    }
                    // if (typeof vGIFT_VOUCHER != 'undefined') {
                    if ($('#GIFT_VOUCHER').val() !== undefined) {
                        TotalGiftAmount = $('#GIFT_VOUCHER').val();
                    }
                    if (typeof Credit_Note != 'undefined') {
                        TotalCredit_NoteAmount = $('#Credit_Note').val();
                    }
                    var Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) + parseInt(TotalGiftAmount) + parseInt(TotalCredit_NoteAmount);
                    //   var Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) + parseInt(TotalGiftAmount);
                    vCurrentBalance = parseInt(Total) - parseInt(vNet_Amount);
                    vBalance = Math.abs(vCurrentBalance);

                    // if (vCurrentBalance <= 0) {
                    if (vBalance > 0) {
                        vCurrentBalance = 0;
                        vBalance = Math.abs(vBalance); //vBalance.replace(/[-]/g, '');
                        $('#PayNet_Amount').prop('disabled', true);
                        $('#span_Pay').hide();

                        $('#span_Point').hide();
                        $('#span_ChangeAmount').show();
                        $('#table_PayButton').hide();
                        // $('#table_Complete_Transection').show();

                    }

                }
                else {
                    vCurrentBalance = parseInt(vNet_Amount) - parseInt(TotalCash);

                    TotalCardAmount = 0,
                        TotalCashAmount = 0,
                        TotalMobileAmount = 0,
                        TotalGiftAmount = 0,
                        TotalCredit_NoteAmount = 0,
                        Card_Amount = document.querySelectorAll('.Card_Amount'),
                        MobileAmount = document.querySelectorAll('.Mobile_Amount'), i,
                        Credit_Note = $('#Credit_Note').val();

                    for (i = 0; i < Card_Amount.length; i++) {
                        TotalCardAmount += parseFloat(Card_Amount[i].value || 0);
                    }
                    for (i = 0; i < MobileAmount.length; i++) {
                        TotalMobileAmount += parseFloat(MobileAmount[i].value || 0);
                    }
                    // if (typeof vCash_Amount != 'undefined') {
                    if ($('#Cash_Amount').val() !== undefined) {
                        TotalCashAmount = $('#Cash_Amount').val();
                    }
                    // if (typeof vGIFT_VOUCHER != 'undefined') {
                    if ($('#GIFT_VOUCHER').val() !== undefined) {
                        TotalGiftAmount = $('#GIFT_VOUCHER').val();
                    }
                    if (typeof Credit_Note != 'undefined') {
                        TotalCredit_NoteAmount = $('#Credit_Note').val();
                    }
                    var Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) + parseInt(TotalGiftAmount) + parseInt(TotalCredit_NoteAmount);

                    //  var Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) + parseInt(TotalGiftAmount);
                    vCurrentBalance = parseInt(vNet_Amount) - parseInt(Total);
                    vBalance = Math.abs(vCurrentBalance);

                    //if (vBalance <= 0) {
                    if (vCurrentBalance <= 0) {
                        vCurrentBalance = 0;
                        vBalance = Math.abs(vBalance); //vBalance.replace(/[-]/g, '');
                        $('#PayNet_Amount').prop('disabled', true);
                        $('#span_Pay').hide();

                        $('#span_Point').hide();
                        $('#span_ChangeAmount').show();
                        $('#table_PayButton').hide();
                        //  $('#table_Complete_Transection').show();
                        //Complete_Transection();
                    }
                }

                AddBalanceRow(vCurrentBalance, vBalance);
            }
            break;
        case "CARD":
            vPayNet_Amount = $('#Card_Amount').val();
            vCash_Amount = $('#Cash_Amount').val();
            //var vTender_ID = $('option:selected', this).val();
            var vCardName = $('#CardType option:selected').text(),
                vCardType = $('#CardType').val(),
                vBankID = $('#CardBank_Name').val(),
                vCard_No = $('#Card_No').val();

            AddCardRow(vCardName, vCardType, Math.abs(vPayNet_Amount), vBankID, vCard_No);

            TotalCardAmount = 0,
                TotalCashAmount = 0,
                TotalMobileAmount = 0,
                TotalGiftAmount = 0,
                TotalCredit_NoteAmount = 0,
                Card_Amount = document.querySelectorAll('.Card_Amount'),
                MobileAmount = document.querySelectorAll('.Mobile_Amount'), i,
                Credit_Note = $('#Credit_Note').val();

            for (i = 0; i < Card_Amount.length; i++) {
                TotalCardAmount += parseFloat(Card_Amount[i].value || 0);
            }
            for (i = 0; i < MobileAmount.length; i++) {
                TotalMobileAmount += parseFloat(MobileAmount[i].value || 0);
            }
            if (typeof vCash_Amount != 'undefined') {
                // if ($('#Cash_Amount').val() !== undefined) {
                TotalCashAmount = $('#Cash_Amount').val();
            }
            if (typeof vGIFT_VOUCHER != 'undefined') {
                // if ($('#GIFT_VOUCHER').val() !== undefined) {
                TotalGiftAmount = $('#GIFT_VOUCHER').val();
            }
            if (typeof Credit_Note != 'undefined') {
                TotalCredit_NoteAmount = $('#Credit_Note').val();
            }
            var Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) + parseInt(TotalGiftAmount) + parseInt(TotalCredit_NoteAmount);

            // var Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) + parseInt(TotalGiftAmount);

            vCurrentBalance = parseInt(vNet_Amount) - parseInt(Total);
            vBalance = Math.abs(vCurrentBalance);

            if (vCurrentBalance <= 0) {

                vCurrentBalance = 0;
                $('#PayNet_Amount').prop('disabled', true);
                $('#span_Pay').hide();

                $('#span_Point').hide();
                $('#span_ChangeAmount').show();
                $('#table_PayButton').hide();
                // $('#table_Complete_Transection').show();
                // Complete_Transection();
            }
            AddBalanceRow(vCurrentBalance, vBalance);
            $("#Modal_Card").modal("hide");

            break;
        case "MOBILE_BANKING":

            vPayNet_Amount = $('#Mobile_Amount').val();
            //  alert(vPayNet_Amount);
            vCash_Amount = $('#Cash_Amount').val();
            var vBankingType = $('#BankingType').val(),
                vCardName = $('#BankingType option:selected').text(),

                vMB_Transection_No = $('#MB_Transection_No').val(),
                vMobileNo = $('#MB_Mobile_No').val();

            AddMobileRow(vCardName, vBankingType, vMobileNo, Math.abs(vPayNet_Amount), vMB_Transection_No);

            //AddMobileRow(vCardName, vCardType, vMobileNo, vPayNet_Amount, vMB_Transection_No) 
            var TotalCardAmount = 0,
                TotalCashAmount = 0,
                TotalMobileAmount = 0,
                TotalCredit_NoteAmount = 0,
                TotalGiftAmount = 0,
                MobileAmount = document.querySelectorAll('.Mobile_Amount'),
                CardAmount = document.querySelectorAll('.Card_Amount'), i,
                Credit_Note = $('#Credit_Note').val();

            //  if ($('#Cash_Amount').val() !== undefined) {
            if (typeof vCash_Amount != 'undefined') {
                TotalCashAmount = $('#Cash_Amount').val();
            }
            for (i = 0; i < CardAmount.length; i++) {
                TotalCardAmount += parseFloat(CardAmount[i].value || 0);
            }
            for (i = 0; i < MobileAmount.length; i++) {
                TotalMobileAmount += parseFloat(MobileAmount[i].value || 0);
            }
            if (typeof vGIFT_VOUCHER != 'undefined') {
                // if ($('#GIFT_VOUCHER').val() !== undefined) {
                TotalGiftAmount = $('#GIFT_VOUCHER').val();
            }
            if (typeof Credit_Note != 'undefined') {
                TotalCredit_NoteAmount = $('#Credit_Note').val();
            }
            else {
                TotalCredit_NoteAmount = 0;
            }
            var Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) + parseInt(TotalGiftAmount) + parseInt(TotalCredit_NoteAmount);

            //   Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount);
            vCurrentBalance = parseInt(vNet_Amount) - parseInt(Total);
            vBalance = Math.abs(vCurrentBalance);

            if (vCurrentBalance <= 0) {

                vCurrentBalance = 0;
                $('#PayNet_Amount').prop('disabled', true);
                $('#span_Pay').hide();

                $('#span_Point').hide();
                $('#span_ChangeAmount').show();
                $('#table_PayButton').hide();
                //   $('#table_Complete_Transection').show();
                //  Complete_Transection();
            }
            AddBalanceRow(vCurrentBalance, vBalance);

            $("#Modal_MobileBanking").modal("hide");
            break;

        case "GIFT_VOUCHER":
            //alert("GIFT_VOUCHER");
            vCash_Amount = $('#Cash_Amount').val();
            var vCoupon_No = $('#Coupon_No').val();
            var vDiscountPercentage = $('#DiscountAmount').text();

            //alert(vCouponType + "" + vCoupon_No + "" + vDiscountAmount);
            var vDiscountAmount = (vNet_Amount * vDiscountPercentage) / 100
            Add_GIFT_VOUCHER_Row(vCoupon_No, vDiscountPercentage, vDiscountAmount);

            var vCurrentBalance = parseInt(vNet_Amount) - parseInt(vDiscountAmount);
            vBalance = Math.abs(vCurrentBalance);

            if (vCurrentBalance <= 0) {
                vCurrentBalance = 0;
                $('#PayNet_Amount').prop('disabled', true);
                $('#span_Pay').hide();
                $('#span_Point').hide();
                $('#span_ChangeAmount').show();
                $('#table_PayButton').hide();
                // $('#table_Complete_Transection').show();
                //  Complete_Transection();
            }
            AddBalanceRow(vCurrentBalance, vBalance);
            $("#Modal_Coupon").modal("hide");
            $('#msgGiftVoucher').hide();
            break;
        case "CREDIT_NOTE":

            vCREDIT_NOTE_No = $('#Credit_Note_No').val();
            vCREDIT_NOTE_Amount = $('#Credit_Note_Amount').val();


            Add_CREDIT_NOTE_Row(vCREDIT_NOTE_No, vCREDIT_NOTE_Amount)

            var TotalCardAmount = 0,
                TotalCashAmount = 0,
                TotalMobileAmount = 0,
                TotalCredit_NoteAmount = 0,
                TotalGiftAmount = 0,
                MobileAmount = document.querySelectorAll('.Mobile_Amount'),
                CardAmount = document.querySelectorAll('.Card_Amount'), i,
                Credit_Note = $('#Credit_Note').val();

            //  if ($('#Cash_Amount').val() !== undefined) {
            if (typeof vCash_Amount != 'undefined') {
                TotalCashAmount = $('#Cash_Amount').val();
            }
            for (i = 0; i < CardAmount.length; i++) {
                TotalCardAmount += parseFloat(CardAmount[i].value || 0);
            }
            for (i = 0; i < MobileAmount.length; i++) {
                TotalMobileAmount += parseFloat(MobileAmount[i].value || 0);
            }
            if (typeof vGIFT_VOUCHER != 'undefined') {
                // if ($('#GIFT_VOUCHER').val() !== undefined) {
                TotalGiftAmount = $('#GIFT_VOUCHER').val();
            }
            if (typeof Credit_Note != 'undefined') {
                TotalCredit_NoteAmount = $('#Credit_Note').val();
            }
            var Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) + parseInt(TotalGiftAmount) + parseInt(TotalCredit_NoteAmount);

            // Total = parseInt(TotalCashAmount) + parseInt(TotalCardAmount) + parseInt(TotalMobileAmount) + parseInt(TotalCredit_NoteAmount);
            vCurrentBalance = parseInt(vNet_Amount) - parseInt(Total);
            vBalance = Math.abs(vCurrentBalance);

            if (vCurrentBalance <= 0) {
                vCurrentBalance = 0;
                $('#PayNet_Amount').prop('disabled', true);
                $('#span_Pay').hide();
                $('#span_Point').hide();
                $('#span_ChangeAmount').show();
                $('#table_PayButton').hide();
                //  $('#table_Complete_Transection').show();
                //  Complete_Transection();
            }
            AddBalanceRow(vCurrentBalance, vBalance);
            //alert("CREDIT_NOTE");
            $("#Modal_CreditNote").modal("hide");






            break;
        case "COUPON":
            alert("COUPON");
            break;
        case "CHEQUE":
            alert("CHEQUE");
            break;
        case "POINT_REDEEM":
            alert("POINT_REDEEM");
            break;
        default:
            alert("Please Select Tenter Type");
            break;
    }
}

function AddCashRow(vPayNet_Amount) {

    $('#CashRow').remove();
    var newRow = "<tr style='font-size: 21px;' id='CashRow'>";
    newRow += "<td style='text-align:left;'>";
    newRow += "<span style='font-weight:200'>Cash </span></td >";
    newRow += "<td style='text-align:right;'><div class='input-group'>";
    newRow += "<input id='Cash_Amount' style='font-size: 21px; font-weight: bold;text-align:right;width: 100%;' type='text' class='form-control' value='" + vPayNet_Amount + "' disabled>";
    newRow += "<span class='input-group-addon'>৳</span></div></td></tr>";

    $('#table_SaleSummary').append(newRow);
}

function AddBalanceRow(vCurrentBalance, vBalance) {

    var newRow = "<tr style='font-size: 21px;' id='BalanceRow'>";
    newRow += "<td style='text-align:left;'>";
    newRow += "<b>Balance</b></td >";
    newRow += "<td style='text-align:right;'><div class='input-group'>";
    newRow += "<input id='Balance' style='font-size: 21px; font-weight: bold;text-align:right;width: 100%;' type='text' class='form-control' value='" + vCurrentBalance + "' disabled>";
    newRow += "<span class='input-group-addon'>৳</span></div></td></tr>";

    $('#BalanceRow').remove();
    $('#table_SaleSummary').append(newRow);
    $('#PayNet_Amount').val(vBalance);
    $('#PayNet_Amount').focus();

}

function AddCardRow(vCardName, vCardType, vPayNet_Amount, vBankID, vCard_No) {
    var vItemNo = $('#btnCard').attr('data-item');
    // First Time We get data-item = 0
    $('#btnCard').attr('data-item', (parseInt(vItemNo) + 1));

    var newRow = "<tr id='tr_" + (parseInt(vItemNo) + 1) + "' style='font-size: 21px;' class='CardRow' data-CardType='" + vCardType + "' data-BankID='" + vBankID + "' data-CardNo='" + vCard_No + "'>";
    newRow += "<td style='text-align:left;'>";
    newRow += "<span style='font-weight:200'>Card </span> <span style='font-size: 10px;'>[" + vCardName + "]</span></td >";
    newRow += "<td style='text-align:right;'><div class='input-group'>";
    newRow += "<input id='Cardrow_" + (parseInt(vItemNo) + 1) + "' style='font-size: 21px; font-weight: bold;text-align:right;width: 100%;' type='text' class='form-control Card_Amount' value='" + vPayNet_Amount + "' disabled>";
    newRow += "<span class='input-group-addon'>৳</span></div></td></tr>";
    $('#table_SaleSummary').append(newRow);

    var vThirdRow = $('#btnCard').attr('data-item');
    if (vThirdRow === '3') {
        $('#btnCard').addClass('disabled');
    }
}

function AddMobileRow(vCardName, vCardType, vMobileNo, vPayNet_Amount, vMB_Transection_No) {

    var vItemNo = $('#btnMobileBanking').attr('data-item');
    // First Time We get data-item = 0
    $('#btnMobileBanking').attr('data-item', (parseInt(vItemNo) + 1));

    var newRow = "<tr style='font-size: 21px;' id='MobileRow' data-MB_Mobile_No='" + vMobileNo + "' data-CardType='" + vCardType + "' data-MB_Transection_No='" + vMB_Transection_No + "'>";
    newRow += "<td style='text-align:left;'>";
    newRow += "<span style='font-weight:200'>Mobile</span> <span style='font-size: 10px;'>[" + vMobileNo + "],[" + vCardName + "]</span></td >";
    newRow += "<td style='text-align:right;'><div class='input-group'>";
    newRow += "<input  id='Mobilerow_" + (parseInt(vItemNo) + 1) + "' style='font-size: 21px; font-weight: bold;text-align:right;width: 100%;' type='text' class='form-control Mobile_Amount' value='" + vPayNet_Amount + "' disabled>";
    newRow += "<span class='input-group-addon'>৳</span></div></td></tr>";
    $('#table_SaleSummary').append(newRow);
    var vThirdRow = $('#btnMobileBanking').attr('data-item');

    if (vThirdRow === '1') {
        $('#btnMobileBanking').addClass('disabled');
    }
}

function Add_CREDIT_NOTE_Row(vCREDIT_NOTE_No, vCREDIT_NOTE_Amount) {
    $('#Credit_Note_Row').remove();
    var newRow = "<tr style='font-size: 21px;' id='Credit_Note_Row' data-credit_note_no='" + vCREDIT_NOTE_No + "' data-credit_note_Amount='" + vCREDIT_NOTE_Amount + "'>";
    newRow += "<td style='text-align:left;'>";
    newRow += "<span style='font-weight:200'>Credit Note</span> <span style='font-size: 10px;'>[" + vCREDIT_NOTE_No + "]</span></td >";
    newRow += "<td style='text-align:right;'><div class='input-group'>";
    newRow += "<input id='Credit_Note' style='font-size: 21px; font-weight: bold;text-align:right;width: 100%;' type='text' class='form-control' value='" + vCREDIT_NOTE_Amount + "' disabled>";
    newRow += "<span class='input-group-addon'>৳</span></div></td></tr>";
    $('#table_SaleSummary').append(newRow);
    $('#btnCreditNote').addClass('disabled');
}

function Add_GIFT_VOUCHER_Row(vCoupon_No, vDiscountPercentage, vDiscountAmount) {
    $('#GIFT_VOUCHER_Row').remove();
    var newRow = "<tr style='font-size: 21px;' id='GIFT_VOUCHER_Row'>";
    newRow += "<td style='text-align:left;'>";
    newRow += "<span style='font-weight:200'>Gift Voucher</span> <span style='font-size: 10px;'>[" + vCoupon_No + "],[" + vDiscountPercentage + "%]</span></td >";
    newRow += "<td style='text-align:right;'><div class='input-group'>";
    newRow += "<input id='GIFT_VOUCHER' style='font-size: 21px; font-weight: bold;text-align:right;width: 100%;' type='text' class='form-control' value='" + vDiscountAmount + "' disabled>";
    newRow += "<span class='input-group-addon'>৳</span></div></td></tr>";
    $('#table_SaleSummary').append(newRow);
}

function Final_Posting() {
    //alert();
    $("#btnComplete_Transection").addClass('disabled');
    var vCash_Amount = $("#Cash_Amount").val(),
        ///////////////////////////////////////////////
        vCard_Amount1 = $('#Cardrow_1').val(),
        vCardType1, vCard1_No, vCard1Bank_ID,

        //////////////////////////////////////
        vCard_Amount2 = $('#Cardrow_2').val(),
        vCardType2, vCard2_No, vCard2Bank_ID,

        ///////////////////////////////////////////
        vCard_Amount3 = $('#Cardrow_3').val(),
        vCardType3, vCard3_No, vCard3Bank_ID,

        /////////////////////////////////////////
        vMobile_Amount = $('#Mobilerow_1').val(),
        vMB_Transection_No = $('#MobileRow').attr('data-MB_Transection_No'),
        vMB_Mobile_No = $('#MobileRow').attr('data-MB_Mobile_No'),
        vMobileBanking_Type = $('#MobileRow').attr('data-CardType'),
        /////////////////////////////////////////
        vCredit_Note_No = $('#Credit_Note_Row').attr('data-credit_note_no'),
        vCredit_Note_Amount = $('#Credit_Note_Row').attr('data-credit_note_Amount');


    if (typeof vCash_Amount !== 'undefined') {
        vCash_Amount = $('#Cash_Amount').val();

    } else {
        vCash_Amount = 0;
    }

    if (typeof vCard_Amount1 !== 'undefined') {
        vCard_Amount1 = $('#Cardrow_1').val();
        vCardType1 = $('#tr_1').attr('data-CardType');
        vCard1_No = $('#tr_1').attr('data-CardNo');
        vCard1Bank_ID = $('#tr_1').attr('data-BankID');
    } else {
        vCard_Amount1 = 0;
        vCardType1 = "";
        vCard1_No = 0;
        vCard1Bank_ID = 0;
    }

    if (typeof vCard_Amount2 != 'undefined') {
        vCard_Amount2 = $('#Cardrow_2').val();
        vCardType2 = $('#tr_2').attr('data-CardType');
        vCard2_No = $('#tr_2').attr('data-CardNo');
        vCard2Bank_ID = $('#tr_2').attr('data-BankID');
    } else {
        vCard_Amount2 = 0;
        vCardType2 = "";
        vCard2_No = 0;
        vCard2Bank_ID = 0;
    }

    if (typeof vCard_Amount3 != 'undefined') {
        vCard_Amount3 = $('#Cardrow_3').val();
        vCardType3 = $('#tr_3').attr('data-CardType');
        vCard3_No = $('#tr_3').attr('data-CardNo');
        vCard3Bank_ID = $('#tr_3').attr('data-BankID');
    }
    else {
        vCard_Amount3 = 0;
        vCardType3 = "";
        vCard3_No = 0;
        vCard3Bank_ID = 0;
    }
    ///////////////////////////////////////

    if (typeof vMobile_Amount != 'undefined') {
        vMobile_Amount = $('#Mobilerow_1').val();
        vMB_Transection_No = $('#MobileRow').attr('data-MB_Transection_No');
        vMB_Mobile_No = $('#MobileRow').attr('data-MB_Mobile_No');
        vMobileBanking_Type = $('#MobileRow').attr('data-CardType');
    } else {
        vMobile_Amount = 0;
        vMB_Transection_No = "";
        vMB_Mobile_No = "";
        vMobileBanking_Type = "";
    }

    if (typeof vCredit_Note_No != 'undefined') {
        vCredit_Note_No = $('#Credit_Note_Row').attr('data-credit_note_no'),
            vCredit_Note_Amount = $('#Credit_Note_Row').attr('data-credit_note_amount');

    }
    else {
        vCredit_Note_No = "";
        vCredit_Note_Amount = 0;
    }
    // var newSrc = '../../Report/RPTViewer.aspx';
    $.ajax({
        type: "POST",
        url: "/Sales/Sales_Barcode_Posting",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                _Cash_Amount: vCash_Amount,
                _Card1_Amount: vCard_Amount1,
                _Card1_Type: vCardType1,
                _Card1_No: vCard1_No,
                _Card1Bank_ID: vCard1Bank_ID,

                _Card2_Amount: vCard_Amount2,
                _Card2_Type: vCardType2,
                _Card2_No: vCard2_No,
                _Card2Bank_ID: vCard2Bank_ID,

                _Card3_Amount: vCard_Amount3,
                _Card3_Type: vCardType3,
                _Card3_No: vCard3_No,
                _Card3Bank_ID: vCard3Bank_ID,

                _MobileBanking_Amount: vMobile_Amount,
                _MobileBanking_Type: vMobileBanking_Type,
                _MobileBankingTransaction_ID: vMB_Transection_No,
                _MobileBankingPhone_No: vMB_Mobile_No,

                _CreditNoteBill_No: vCredit_Note_No,
                _CreditNote_Amount: vCredit_Note_Amount
            }),

        success: function (response) {
            if (response) {
                //alert("jggh");
                //  let newWindow = open('../../Sales/PDFPrint', "", 'width=2,height=2');
                ////  win3 = window.open("page.htm", "", "width=600,height=500")
                //  newWindow.moveTo(screen.width, screen.height);
                //  newWindow.onload = function () {
                //      newWindow.print();
                //  };
                //  setTimeout(function () {
                //      newWindow.close();
                //      BackToSale();
                //  }, 1000);
                //  return false;
                BackToSale();
            }
            else {
                PlaySound();
                toastr.error("CAN'T SAVE !!! ", "Transaction FAIL... PLEASE TRY AGAIN ",
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
            // alert(response.responseText);
            PlaySound();
            location.reload();
        },
        error: function (response) {
            // alert(response.responseText);
            PlaySound();
            location.reload();
        }
    });
}

function ChannelList() {

    $.ajax({
        url: '/Channel/ChannelList',
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.length > 0) {
                $('select#ChannelList').html('');
                var result = '';
                result += "<option value='0' title='0'>--Select--</option>";
                for (var i = 0; response.length > i; i++)
                {
                    result += "<option title='" + response[i].DC_ID + "' value='" + response[i].DC_ID + "' data-shortname='" + response[i].DCHANNEL + "'>" + response[i].DCHANNEL + "</option>";
                }
                $('select#ChannelList').append(result);
            }

        }
    });
}

$('#ChannelList').on("select2:select", function (e) {
    var vChID = $("#ChannelList").val();
    // alert(vChID);

    $.ajax({
        url: '/Channel/Channel_Customer_List',
        type: 'POST',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(
            {
                _ChID: vChID
            }
        ),
        success: function (response) {
            if (response.length > 0) {

                $('select#CustomerList').html('');
                var result = '';
                result += "<option value='0' title='0'>--Select--</option>";
                for (var i = 0; response.length > i; i++) {
                    result += "<option id='" + response[i].PInt_ID + "' title='" + response[i].PInt_ID + "' value='" + response[i].PInt_ID + "' data-discount='" + response[i].DiscAllowed + "'>" + response[i].PartnerName + "</option>";
                }
                $('select#CustomerList').append(result);
                //DO


            }
        }
    });
});

$('#Modal_FinalPosting_Done').on('hidden.bs.modal', function (e) {

    $('#Modal_FinalPosting_Done').attr('data-modal', 'Close');
});

$('#Modal_FinalPosting_Done').on('shown.bs.modal', function (e) {

    $('#Modal_FinalPosting_Done').attr('data-modal', 'Open');
    $('#btnDirectPrint').focus();


});


function DirectPrint() {

    $("#Modal_FinalPpsting_Done").modal("hide");

    var vUser_ID = $('#User_ID').attr('data-UserID');
    let newWindow = open('../../PDF/' + vUser_ID + 'Retail_Memo.pdf', "", 'width=50,height=50');
    newWindow.onload = function () {
        newWindow.print();

    };
    setTimeout(function () {
        newWindow.close();
        BackToSale();
    }, 2000);
    return false;
}
$("#Modal_CreditNote #Credit_Note_No").change(function () {
    var _amount = $(this).find(':selected').attr('data-amount')

    $('#Modal_CreditNote #Credit_Note_Amount').val(_amount);
    $('#Modal_CreditNote #btn_CreditNote').focus();


});

function Credit_Note_Load() {

    $('#Modal_CreditNote select#Credit_Note_No').html("");

    $.ajax({
        type: "POST",
        url: "/Sales/SalesReturn_CN_List",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            result = "";
            result = "<option value='0'>- -  Select  - -</option>";
            if (response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    result += "<option  value='" + response[i].External_ID + "' data-amount='" + response[i].Return_Amount + "'>" + response[i].External_ID + " [" + response[i].Document_Date + "] </option>";
                }
            }
            $('#Modal_CreditNote select#Credit_Note_No').append(result);
        }
    });

}
