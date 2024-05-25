$(function () {

    $('#rightTab').tabs();

    var todayDate = new Date( $("#dateFrom").val());
    var tomorrowDate = new Date($("#dateTo").val());

const monthNamesList = ["January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December"
];
const weeknameList = [ "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
];

$(".customDateWrap .month").html(monthNamesList[todayDate.getMonth()]);
$(".customDateWrap .day").html(todayDate.getDate());
    $(".customDateWrap .week").html(weeknameList[todayDate.getDay()]);


$(".customDateWrapreturn .monthreturn").html(monthNamesList[tomorrowDate.getMonth()]);
$(".customDateWrapreturn .dayreturn").html(tomorrowDate.getDate());
    $(".customDateWrapreturn .weekreturn").html(weeknameList[tomorrowDate.getDay()]);


    $("#dateFrom").datepicker({
        dateFormat: 'mm-dd-yy',
        changeMonth: false,
        minDate: new Date(),
        maxDate: '+2y',
        onSelect: function (date, dateText, inst) {

            var selectedDate = new Date(date);
            var msecsInADay = 86400000;
            var endDate = new Date(selectedDate.getTime() + msecsInADay);

            //Set Minimum Date of EndDatePicker After Selected Date of StartDatePicker
            //$("#dateTo").datepicker( "option", "minDate", endDate );
            $("#dateTo").datepicker("option", "maxDate", '+2y');

            var date = $(this).datepicker('getDate'),
                day = date.getDate(),
                week = date.getDay();
            var month_name = function (dt) {
                mlist = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
                return mlist[dt.getMonth()];
            };
            var week_name = function (wk) {
                mlist = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
                return mlist[wk.getDay()];
            };
            $(".day").html(day);
            $(".month").html(month_name(date));
            $(".week").html(week_name(date));

            //$("#dateFrom").hide();
            $(".customDateWrap").show();

            $("#dateTo").datepicker("option", "minDate", date);

            $(".dayreturn").html(day);
            $(".monthreturn").html(month_name(date));
            $(".weekreturn").html(week_name(date));
        }
    });
    $("#dateFrom").datepicker().datepicker("setDate", todayDate);

$(".customDateWrap").click(function(){ $("#dateFrom").datepicker("show"); });
    $(".customDateWrapreturn").click(function () { $("#dateTo").datepicker("show"); });

$('.customDateWrap').datepicker( "setDate" ,  new Date());

$("#dateTo").datepicker({ 
    dateFormat: 'mm-dd-yy',
    changeMonth: false
    ,
    onSelect: function (date, dateText, inst) {


        var dateTo = $("#dateFrom").datepicker('getDate');
        $("#dateTo").datepicker("option", "minDate", dateTo);

      var date = $(this).datepicker('getDate'),
                     day  = date.getDate(),             
            week = date.getDay();     
        
                 var month_name = function(dt){
                          mlist = [ "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" ];
                          return mlist[dt.getMonth()]; 
                         };
                          var week_name = function(wk){
                          mlist = [  "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
                          return mlist[wk.getDay()]; 
                         };
                         $(".dayreturn").html(day);
                         $(".monthreturn").html(month_name(date));
                         $(".weekreturn").html(week_name(date));
                         //$("#dateTo").hide();
        $(".customDateWrapreturn").show();
        $("#RoundTrip").trigger("click");
        $('.customDateWrapreturn').removeClass("colorDisabled");
    }
});


$(".radioClick").click(function(){
            var radioValue = $("input[name='tripType']:checked").val();
            if(radioValue=="OneWay"){
                 $('.customDateWrapreturn').addClass("colorDisabled").prop("disabled",true);
            }
            else{
                 // $('#dateTo').prop('disabled',false);
                $('.customDateWrapreturn').removeClass("colorDisabled").prop("disabled", false);;
            }
        });
 $('.dropdown-trigger').dropdown({
  closeOnClick:false
 });

   

  // var clicks = 0; $("#like").click(function(){ clicks++; $('.figure').html(clicks);});
var countadult=1;
var countchild=0;
var countinfant=0;
if(countadult<1){
       $(".adultminus").addClass("pointerEventNone");
     }
      if(countchild<1){
       $(".childMinus").addClass("pointerEventNone");
     }
      if(countinfant<1){
       $(".infantMinus").addClass("pointerEventNone");
    }

    if (countadult + countchild + countinfant < 9) {
        $(".childPlus").removeClass("pointerEventNone");
        $(".adultPlus").removeClass("pointerEventNone");
        $(".infantPlus").removeClass("pointerEventNone");
    }
    if (countadult + countchild + countinfant >= 9) {
        $(".childPlus").addClass("pointerEventNone");
        $(".adultPlus").addClass("pointerEventNone");
        $(".infantPlus").addClass("pointerEventNone");
    }

    $(".adultPlus").click(function (event){
     $(".adultminus").removeClass("pointerEventNone");
      if (countadult + countchild + countinfant >= 9) {
      $(this).addClass("pointerEventNone");
      }
      else
    countadult++;
      $('.adultVal').html(countadult);
      $('.adultVal').val(countadult);
      event.stopPropagation();
  });
  $(".adultminus").click(function(event){
      $(".adultPlus").removeClass("pointerEventNone");
      if (countadult + countchild + countinfant < 9) {
          $(".childPlus").removeClass("pointerEventNone");
          $(".adultPlus").removeClass("pointerEventNone");
          $(".infantPlus").removeClass("pointerEventNone");
      }
     if(countadult==1){
      $(this).addClass("pointerEventNone");
     }
     else
          countadult--;
      if (countinfant >= countadult)
          $(".infantMinus").click();
      $('.adultVal').html(countadult);
      $('.adultVal').val(countadult);
      event.stopPropagation();
  });
  $(".childPlus").click(function(event){
     $(".childMinus").removeClass("pointerEventNone");
      if (countadult + countchild + countinfant >= 9){
      $(this).addClass("pointerEventNone");
      }
      else
    countchild++;
      $('.childVal').html(countchild);
      $('.childVal').val(countchild);
      event.stopPropagation();
  });
  $(".childMinus").click(function(event){
      $(".childPlus").removeClass("pointerEventNone");
      if (countadult + countchild + countinfant < 9) {
          $(".childPlus").removeClass("pointerEventNone");
          $(".adultPlus").removeClass("pointerEventNone");
          $(".infantPlus").removeClass("pointerEventNone");
      }
      if (countchild == 0) {
      $(this).addClass("pointerEventNone");
      }
      else
    countchild--;
      $('.childVal').html(countchild);
      $('.childVal').val(countchild);
     
      event.stopPropagation();
  });
    $(".infantPlus").click(function (event) {
     $(".infantMinus").removeClass("pointerEventNone");
      if ((countadult + countchild + countinfant >= 9) || countinfant >= countadult) {
      $(this).addClass("pointerEventNone");
      }
      else
    countinfant++;
      $('.infantVal').html(countinfant);
      $('.infantVal').val(countinfant);

      event.stopPropagation();
  });
  $(".infantMinus").click(function(event){
      $(".infantPlus").removeClass("pointerEventNone");
      if (countadult + countchild + countinfant < 9) {
          $(".childPlus").removeClass("pointerEventNone");
          $(".adultPlus").removeClass("pointerEventNone");
          $(".infantPlus").removeClass("pointerEventNone");
      }
      if (countinfant == 0){
      $(this).addClass("pointerEventNone");
     }
     else
    countinfant--;
      $('.infantVal').html(countinfant);
      $('.infantVal').val(countinfant);

      event.stopPropagation();
  });

    $('input.radioClick').on('click', function () {
        $(".classSelected").html(($('input[name=class]:checked').val()));
    });

$(".plus").click(function(){
  var totalCount=countadult+countchild+countinfant;
  $(".passengercount").html(totalCount);
  
});
$(".minus").click(function(){
  var totalCount=countadult+countchild+countinfant;
  $(".passengercount").html(totalCount);
  
});
});

var textHandler = new TagFinder(null);

function loadAirport(e, strDiv, root) {
    textHandler.divTag = document.getElementById(strDiv);
    textHandler.textTag = root;
    textHandler.divTag.innerHTML = "";
    var airportInfo;
    var inputValue = root.value.replace(/   /g, '');
    inputValue = removesplchar(inputValue);
    if ((inputValue.length >= 3) && (inputValue !== "undefined")) {
        //if (DivKeyHandler(e) === true) {
        ShowHideDiv(false);
        var rootUrl = window.location.origin ? window.location.origin + '/' : window.location.protocol + '/' + window.location.host + '/';
        $.get(rootUrl + "airport", { input: inputValue }, function (data) {
            // var JsonObj = jQuery.parseJSON(data);
            var suggest = "";
            var clickAction = "";
            suggest += "<ul class='loaderComplete'>";
            $.each(data, function (key, value) {
                airportInfo += value.airportName + "(" + value.airportCode + ")" + ' ,';
                var cityInfo = value.airportName + " (" + value.airportCode + ")";
                if (airportInfo != "") {
                    clickAction = "Suggest(this)";
                }
                else {
                    clickAction = "void(0);";
                }
                if (i == 1) {
                    suggest += "<li ><span class='flR'>Airports</span> <i class='fa fa-building cities' aria-hidden='true'> &nbsp; </i>";
                    suggest += "</li>";
                }

                suggest += "<li onMouseOver='SuggestOver(this)' value=\"" + value.airportCode + "," + value.latitude + "," + value.longitude + "\" onMouseOut='SuggestOut(this)' ><strong></strong>" + cityInfo + "</li>";
                
            });
            //var shortList = airportInfo.split(',');
            //$('#origin').autocomplete({
            //    data:
            //        { [shortList]: null }
            //});suggest += "</ul>";
            textHandler.divTag.innerHTML += suggest + "</ul>";
            ShowHideDiv(true);
        });
        // }
    }
    else
        ShowHideDiv(false);

}
function TagFinder(strDiv) {
        var spanTag;
        var textTag;
    return strDiv;
    }
    var removesplchar = function (input) {
        ret = '';
        for (i = 0; i < input.length; i++) {
            charCode = input.charCodeAt(i);
            if ((charCode <= 127) && (charCode != 34) && (charCode != 38) &&
                (charCode != 60) && (charCode != 62))
                ret += input.charAt(i);
            else
                ret += '&#' + charCode + ';';
        }
        return ret;
    }
    var DivKeyHandler = function (e) {
        var evt = (window.event) ? event : e;
        if (!evt)
            evt = window.event;

        var keyCode = evt.keyCode;
        var BKSPC = 8;
        var TAB = 9;
        var ALT = 18;
        var UP = 38;
        var DOWN = 40;
        var LEFT = 37;
        var RIGHT = 39;
        var ENTER = 13;
        var SHIFT = 16;
        var ESC = 27;
        var HOME = 36;
        var END = 35;
        var CTRL = 17;
        var LEFTARROW = 37;
        var UPARROW = 38;
        var RIGHTARROW = 39;
        var DOWNARROW = 40;

        var currValue = textHandler.textTag.value;

        //Return value will determine if fresh request to WS is to be sent.
        // False - No request
        // True - Send request (refresh)
        switch (keyCode) {
            case HOME:
            case END:
            case SHIFT:
            case CTRL:
            case LEFTARROW:
            case RIGHTARROW:
                return false;
            case BKSPC:
                return true;
            case TAB:
                ShowHideDiv(false);
                return false;
            case UP:
                ScrollSpan("up");
                return false;
            case DOWN:
                ScrollSpan("down");
                return false;
            case ENTER:
                Suggest(textHandler.spanTag);
                ShowHideDiv(false);
                return false;
            case ESC:
                ShowHideDiv(false);
                return false;
            default:
                return true;
        }
    }
var is_undefined = function (value) {
    var undefined_check;

    if (typeof (value) !== undefined_check && value !== null) {
        return false;
    } else {
        return true;
    }


};

function ShowHideDiv(show) {

    var tag = textHandler.divTag;
    if (tag.style.display == "block" || tag.style.display == "") {
        if (show == false) {
            tag.style.display = "none";
        }
    }
    else {	// if tag.style.visibility == "hidden"
        if (show == true) {

            tag.style.display = "block";


        }
    }

}

function SuggestOver(tag) {
    tag.className = "highlight";
}

function SuggestOut(tag) {
    tag.className = "highlight";
}

function Suggest(tag) {

    var value = tag.value;
    textHandler.textTag.value = value;
    ShowHideDiv(false);
}
$(document).ready(function () {
$(document).on("click", ".highlight", function () {
    //$(".highlight").click(function () {
    var destLatLong = $(this).attr("value").split(",");
    if (destLatLong.length > 1) {
        textHandler.textTag.value = destLatLong[0];
        //textHandler.divTagLAt.value = destLatLong[1];
        //textHandler.divTagLong.value = destLatLong[2];
    }
    else {
        textHandler.textTag.value = $(this).attr("value");
    }
    //textHandler.textTag.value = $(this).attr("value");
    ShowHideDiv(false);
});

    $.get("../Banner/GetDetails/Home", function (data) {
            $.each(data, function (key, value) {
                $("#"+value.divName).html(value.content);
            });
        }, "json").fail(function (jqXHR, textStatus, errorThrown) {
            console.log(data);
            alert(textStatus);
        });
});