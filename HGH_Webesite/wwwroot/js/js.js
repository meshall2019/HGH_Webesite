
// for the Sections page
$(".navbar-toggler").click(function(){


$(".section_table").toggle()
$(".section_table").css(" width: 100%;")
$(".each_setcion").hide()


})
$('#list-tab a').on('click', function (e) {
    e.preventDefault()
    $(this).tab('show')
  });
// End of the section page

// for the about page
$("#info").click(function(){

$(".addContents h4").text(":مستشفى حائل العام")
$(".addContents .row h6").text("تقديم خدمات صحية امنه وتحسين مستمر لعملائنا,ومنع الأذى والمخاطر من الوصول لهم")
$("#v").hide()

})

$("#message").click(function(){

  $(".addContents h4").text(":الرسالة")
  $(".addContents .row h6").text("تقديم خدمات صحية امنه وتحسين مستمر لعملائنا,ومنع الأذى والمخاطر من الوصول لهم")
  $("#v").hide()
})

$("#vision").click(function(){

  $(".addContents h4").text(":الرؤية")
  $(".addContents .row h6").text("ان تكون خدماتنا الصحية الافضل في المملكة العربية السعودية")
  $("#v").hide()
})

$("#value").click(function(){

 $(".addContents").hide()
 $("#v").show()

})
// End of the about page

// For the statisticsPage
$('.count').each(function () {
  $(this).prop('Counter',0).animate({
      Counter: $(this).text()
  }, {
      duration: 4000,
      easing: 'swing',
      step: function (now) {
          $(this).text(Math.ceil(now));
      }
  });
});
// End of statisticsPage

// For NewsPage

var today = new Date();
var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();

$(".np .justify-content-center p").append(" "+date)

// End

// For SeeNews Page



new WOW().init();















