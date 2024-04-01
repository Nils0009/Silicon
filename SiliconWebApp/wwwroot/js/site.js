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

