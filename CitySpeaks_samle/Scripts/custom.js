$('.owl-carousel').owlCarousel({
    items: 1,
    loop: true,
    dots: true
});

function animateImgFunc() {
    $(".owl-carousel .active .inner-testimonial img").addClass("animated bounceIn full-opacity");
}

//Удаляем класс с анимацией изображения
function animateImgClear() {
    $(".owl-carousel .active .inner-testimonial img").removeClass("animated bounceIn full-opacity");
}