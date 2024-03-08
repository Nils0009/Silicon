document.addEventListener('DOMContentLoaded', function () {
    const mobileMenuButton = document.querySelector('.mobile-menu-btn');
    const mobileMenu = document.querySelector('.mobile-menu');

    mobileMenuButton.addEventListener('click', function () {
        if (mobileMenu.style.display === 'flex') {
            mobileMenu.style.display = 'none';
        } else {
            mobileMenu.style.display = 'flex';
        }
    });

    function hideMobileMenu() {
        mobileMenu.style.display = 'none';
    }

    hideMobileMenu();
    window.addEventListener('resize', hideMobileMenu);
});


function toggleDarkMode() {
    var body = document.body;
    var isDarkMode = body.classList.toggle("dark-mode");

    var lightLogo = document.getElementById("lightmode-logo");
    var darkModeLogo = document.getElementById("darkmode-logo");

    var appstorelightmode = document.getElementById('appstore-lightmode')
    var appstoredarkmode = document.getElementById('appstore-darkmode')

    var googleplaylightmode = document.getElementById('googleplay-lightmode')
    var googleplaydarkmode = document.getElementById('googleplay-darkmode')

    if (isDarkMode) {
        lightLogo.style.display = "none";
        darkModeLogo.style.display = "block";

        appstorelightmode.style.display = "none";
        appstoredarkmode.style.display = "block";

        googleplaylightmode.style.display = "none";
        googleplaydarkmode.style.display = "block";
    }

    else {
        lightLogo.style.display = "block";
        darkModeLogo.style.display = "none";

        appstorelightmode.style.display = "block";
        appstoredarkmode.style.display = "none";

        googleplaylightmode.style.display = "block";
        googleplaydarkmode.style.display = "none";
    }
}

var slideIndex = 1;
showDivs(slideIndex);

function plusDivs(n) {
    showDivs(slideIndex += n);
}

function currentDiv(n) {
    showDivs(slideIndex = n);
}

function showDivs(n) {
    var i;
    var x = document.getElementsByClassName("courses-showcase-content");
    var dots = document.getElementsByClassName("slide-btn");

    if (n > x.length) {
        slideIndex = 1
    }

    if (n < 1) {
        slideIndex = x.length
    }

    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }

    for (i = 0; i < dots.length; i++) {
        dots[i].classList.remove("btn-theme");
        dots[i].classList.add("btn-gray");
    }

    x[slideIndex - 1].style.display = "grid";
    dots[slideIndex - 1].classList.remove("btn-gray");
    dots[slideIndex - 1].classList.add("btn-theme");

}

function toggleDropdown() {
    var dropdown = document.getElementById("myDropdown");
    if (dropdown.style.display === "block") {
        dropdown.style.display = "none";
    } else {
        dropdown.style.display = "block";
    }
}

window.onclick = function (event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        for (var i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.style.display === "block") {
                openDropdown.style.display = "none";
            }
        }
    }
}