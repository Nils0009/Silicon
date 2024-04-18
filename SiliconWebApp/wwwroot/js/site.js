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
    searchQuery()
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
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            console.log("Clicked on 'All categories'")
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none' : 'block'
        })

        let options = selectOptions.querySelectorAll('.option');
        options.forEach(function (option) {
            option.addEventListener('click', function () {

                selected.innerHTML = this.textContent

                selectOptions.style.display = 'none'
                let category = this.getAttribute('data-value')
                selected.setAttribute('data-value', category)
                console.log(category)
                updateCourseByFilter();
            })
        })
    } catch (e) {
        console.log(e);
    }
}

function searchQuery() {
    try {
        const searchField = document.querySelector('#searchQuery');

        searchField.addEventListener('keyup', function () {
            updateCourseByFilter();
        });
    } catch (e) {
        console.log(e);
    }
}
function updateCourseByFilter() {
    console.log('Update course by filter function called.');
    const category = document.querySelector('.select .selected').getAttribute('data-value') || 'all';
    const searchQuery = document.querySelector('#searchQuery').value.toLowerCase();

    const url = `/courses/index?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchQuery)}`;
    console.log('Fetching courses from:', url);
    console.log(category);

    fetch(url)
        .then(res => res.text())
        .then(data => {
            const parser = new DOMParser();
            const dom = parser.parseFromString(data, 'text/html');
            console.log('Parsed DOM:', dom);
            const showcaseContent = document.querySelector('.courses-showcase-content');
            showcaseContent.innerHTML = dom.querySelector('.courses-showcase-content').innerHTML;

            const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : '';
            document.querySelector('.pagination').innerHTML = pagination
        })
        .catch(error => {
            console.error('Error fetching courses:', error);
        });
}


