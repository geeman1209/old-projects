$(document).ready(function(){
var appId = "6ea8f9f6b3e9d73f6b1bfbf2275f9e1c";
var units = $('#units').val();
var zipcode = $('#zipcode').val();


  $('#weather-button').click(function(event){
    $.ajax({
      type: "GET",
      url:"http://api.openweathermap.org/data/2.5/weather?appid="+appId+'&zip='+$('#zipcode').val()+'&units='+units,
      success: function(data, status){
      //Add City Name to h2
      $('#city').append().text('Current city is '+ data.name);
      //  get picture -> icon
      var picID = data.weather[0].icon;
      var pic = "http://openweathermap.org/img/w/"+picID+".png";
      //add picture to column
      $('#icon').append().html('<img src = '+ pic +'>');
      //add description of picture
      $('#descript').append().text(data.weather[0].description);
      //add temp-wind-humidity information
      $('#temp').append().text("Temperature: " + data.main.temp);
      $('#wind').append().text("Wind: " + data.wind.speed);
      $('#humidity').append().text("Humidity: "+ data.main.humidity);

      $('#currentConditions').show();

    },
    error: function(){
      $('#errors')
            .append($('<li>')
            .attr({class:'list-group-item list-group-item-danger'})
            .text('There has been an error. Please try again'));
    }
  })

  $.ajax({
    type: "GET",
    url:"http://api.openweathermap.org/data/2.5/forecast/daily?appid="+appId+'&zip='+$('#zipcode').val() + '&units='+units,
    success: function(data, status){
      var mes = Month();
      var dia = Day();
      var imageLink = '<img src="http://openweathermap.org/img/w/';
      //add Monday
      $('#Mon').append().html('<p>'+mes()+" "+dia(0)+'</p>' +imageLink+ data.list[0].weather[0].icon+'.png">'+' '+data.list[0].weather[0].main + "<p>High: "+data.list[0].temp.max + "Low: "+
      data.list[0].temp.min + '</p>' );
      $('#Tues').append().html('<p>'+mes()+" "+dia(1)+'</p>' +imageLink+ data.list[1].weather[0].icon+'.png">'+' '+data.list[1].weather[0].main + "<p>High: "+data.list[1].temp.max + "Low: "+
      data.list[1].temp.min + '</p>');
      $('#Wed').append().html('<p>'+mes()+" "+dia(2)+'</p>'+imageLink+ data.list[2].weather[0].icon+'.png">'+' '+data.list[2].weather[0].main + "<p>High: "+data.list[2].temp.max + "Low: "+
      data.list[2].temp.min + '</p>' );
      $('#Thurs').append().html('<p>'+mes()+" "+dia(3)+'</p>'+imageLink+ data.list[3].weather[0].icon+'.png">'+' '+data.list[3].weather[0].main + "<p>High: "+data.list[3].temp.max + "Low: "+
      data.list[3].temp.min + '</p>' );
      $('#Fri').append().html('<p>'+mes()+" "+dia(4)+'</p>'+imageLink+ data.list[4].weather[0].icon+'.png">'+' '+data.list[4].weather[0].main + "<p>High: "+data.list[4].temp.max + "Low: "+
      data.list[4].temp.min + '</p>' );


      $('#five-weather').show();
    },

    error: function() {
      $('#errors')
            .append($('<li>')
            .attr({class:'list-group-item list-group-item-danger'})
            .text('There has been an error. Please try again'));
    }

  });
 }

function Month() {
  var d = new Date();
  var month = new Array();
  month[0] = "January";
  month[1] = "February";
  month[2] = "March";
  month[3] = "April";
  month[4] = "May";
  month[5] = "June";
  month[6] = "July";
  month[7] = "August";
  month[8] = "Septemeber";
  month[9] = "October";
  month[10] = "November";
  month[11] = "December";

  var finalMonth = month[d.getMonth()];
  return finalMonth
  }

  function Day(num){
    var d = new Date();
    var dayOfWeek = new Array();
    dayOfWeek[0] = "Sunday";
    dayOfWeek[1] = "Monday";
    dayOfWeek[2] = "Tuesday";
    dayOfWeek[3] = "Wednesday";
    dayOfWeek[4] = "Thursday";
    dayOfWeek[5] = "Friday";
    dayOfWeek[6] = "Saturday";

    var dayIWant = dayOfWeek[0 + num];

    return dayIWant;
  }

function checkErrors(input){
  $('#errorMessage').empty();
  var errors = [];

  input.each(function() {
    if(!this.validity.valid){
      var error = $('label[for=' +this.id+']' ]).text();
      errors.push(error+''+this.validationMessage);
    }
  });
if(errors.length > 0)
{
  $.each(errors,function(index, message){
    $('errors').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
  });
  return true;
}
else
  {
  return false;
  }
}

}
