document.addEventListener('DOMContentLoaded', function () {
    const mobileMenuButton = document.querySelector('.mobile-menu-btn');
    const mobileMenu = document.querySelector('.mobile-menu');
    let sw = document.querySelector('#switch-mode')
    mobileMenuButton.addEventListener('click', function () {
        if (mobileMenu.style.display === 'flex') {
            mobileMenu.style.display = 'none';
        } else {
            mobileMenu.style.display = 'flex';
        }
    });

    sw.addEventListener('change', function() {
        let theme = this.checked ? "dark" : "light"

        fetch(`/sitesettings/changetheme?mode=${theme}`)
            .then(res => {
                if (res.ok)
                window.location.reload()
            })
    })

    function hideMobileMenu() {
        mobileMenu.style.display = 'none';
    }

    hideMobileMenu();
    window.addEventListener('resize', hideMobileMenu);

    handleProfileImageUpload();

    select()
});

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

function handleProfileImageUpload() {
    try {

        let fileUploader = document.querySelector('#fileUploader')

        if (fileUploader != undefined) {
            fileUploader.addEventListener('change', function () {
                if (this.files.length > 0)
                    this.form.submit()
            })
        }
    }
    catch (e) {
        console.log(e)
    }
} 

function select() {
    try {
        let selectOptions = document.getElementById('myDropdown');
        let selected = document.querySelectorAll('.selected');

        // Visa eller dölj dropdown-menyn när du klickar på någon av "All categories"-elementen
        selected.forEach(function (element) {
            element.addEventListener('click', function () {
                selectOptions.classList.toggle('show');
                this.classList.toggle('hide'); // Dölj det klickade "All categories"-elementet
            });
        });

        // Lyssna på klickhändelser för varje kategori
        let options = selectOptions.querySelectorAll('.option');
        options.forEach(function (option) {
            option.addEventListener('click', function () {
                // Uppdatera texten för den valda kategorin i "All categories"
                selected.forEach(function (element) {
                    element.textContent = this.textContent;
                    element.classList.remove('hide'); // Visa det andra "All categories"-elementet igen
                }.bind(this));
                // Dölj dropdown-menyn när du väljer en kategori
                selectOptions.classList.remove('show');

                let category = this.getAttribute('data-value');
                // Använd kategorin på önskat sätt, t.ex. för att filtrera kurser
                console.log(category);
            });
        });
    } catch (e) {
        console.log(e);
    }
}
