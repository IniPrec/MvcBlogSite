document.addEventListener('DOMContentLoaded', function () {
    const searchBox = document.getElementById('searchBox');
    if (searchBox) {
        searchBox.addEventListener('input', function () {
            const query = this.value.toLowerCase();
            document.querySelectorAll('.post-entry').forEach(entry => {
                const title = entry.querySelector('.post-title').textContent.toLowerCase();
                entry.style.display = title.includes(query) ? '' : 'none';
            });
        });
    }
});