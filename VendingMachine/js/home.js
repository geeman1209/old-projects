$(document).ready(function () {

loadMachine();

$('.add-money').click(function(event){
  var money = parseFloat ($('#totalCash').val());
  var money2add = parseFloat($(this).val());
  var totalMoney = money + money2add;

    $('#totalCash').val((totalMoney).toFixed(2));
});

$('#purchase-button').click(function(event){
    var total = $('#totalCash').val();
    var itemId = $('#itemSelect').val();
    $.ajax({
        type:'GET',
        url: 'http://localhost:8080/money/' + total + '/item/' + itemId,
        success: function(data, status){
            $('#messages').val("Thank You!");
            var quarters = data.quarters + " Quarters";
            var dimes = data.dimes + " Dimes";
            var nickels = data.nickels + " Nickels";
            var returnChange = quarters + " "+ dimes +" "+ nickels;

            $('#change').val(returnChange);
            $('#totalCash').val("0");
            $('#purchase-button').hide();
            $('#return-change').hide();
            $("#reset").removeClass("hidden");


          $('#reset').click(function(){
            location.reload();
          });
        },

        error: function(jqXHR, status){
          if(jqXHR.status == 422){
            $('#messages').val(jqXHR.responseJSON.message);
          }
          else if(jqXHR.status == 404){
            $('#messages').val("Please choose an item");
          }
        }
    });
});

$('#return-change').click(function(event){
  var total = $('#totalCash').val()*100;
  var quarters = Math.floor(total / 25);
  var dimes = Math.floor((total - (quarters*25))/10);
  var nickels = Math.floor((total - ((quarters*25)+(dimes*10)))/5)

  var totalReturn = quarters + " Quarters " + dimes + " Dimes " + nickels + " Nickels";

  $('#totalCash').val("0");
  $('#messages').val("");
  $('#itemSelect').val("");
  $('#change').val(totalReturn);
    $('#return-change').hide();
    $("#reset").removeClass("hidden");

    $('#reset').click(function(){
            location.reload();
          });

});


});

function loadMachine(){

$.ajax({
  type: 'GET',
  url: 'http://localhost:8080/items',
  success: function(data, status){
      $.each(data, function(index, item){
      var name = item.name;
      var price = item.price;
      var quantity = item.quantity;
      var id = item.id;

      var item = '<div id='+id+' class="col-md-3 item">';
          item += '<p align="left">' + id + '</p>';
          item += '<p>' + name + '</p>';
          item += '<p>' + '$' + price.toFixed(2) + '</p>';
          item += '<p>' + 'Quantity: ' + quantity + '</p></div>'

          if(id <= 3)
          {
            $('.row1').append(item);
          }
          else if(id <= 6)
          {
            $('.row2').append(item);
          }
          else
          {
            $('.row3').append(item);
          }

          selectItem(id);
      });
  },
    error: function() {
        $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service. Please try again'));
    }
});
}

function selectItem(id){
  $("#" + id).on("click",function(){
    $('#itemSelect').val(id);
});
}
