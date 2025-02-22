document.addEventListener('DOMContentLoaded', function() {
    const blogPosts = document.querySelectorAll('.blog-post');
    const pageNumbers = document.querySelectorAll('.page-number');
    const prevButton = document.querySelector('.prev-page');
    const nextButton = document.querySelector('.next-page');
    let currentPage = 1;
    const totalPages = 3;

    // Function to show posts for a specific page
    function showPage(pageNum) {
        blogPosts.forEach(post => {
            if (post.getAttribute('data-page') == pageNum) {
                post.style.display = 'block';
            } else {
                post.style.display = 'none';
            }
        });

        // Update active page number
        pageNumbers.forEach(num => {
            if (num.getAttribute('data-page') == pageNum) {
                num.classList.add('active');
            } else {
                num.classList.remove('active');
            }
        });

        // Update prev/next button states
        prevButton.style.opacity = pageNum === 1 ? '0.5' : '1';
        prevButton.style.pointerEvents = pageNum === 1 ? 'none' : 'auto';
        nextButton.style.opacity = pageNum === totalPages ? '0.5' : '1';
        nextButton.style.pointerEvents = pageNum === totalPages ? 'none' : 'auto';

        currentPage = pageNum;
    }

    // Initialize first page
    showPage(1);

    // Add click events to page numbers
    pageNumbers.forEach(num => {
        num.addEventListener('click', (e) => {
            e.preventDefault();
            const pageNum = parseInt(num.getAttribute('data-page'));
            showPage(pageNum);
        });
    });

    // Add click events to prev/next buttons
    prevButton.addEventListener('click', (e) => {
        e.preventDefault();
        if (currentPage > 1) {
            showPage(currentPage - 1);
        }
    });

    nextButton.addEventListener('click', (e) => {
        e.preventDefault();
        if (currentPage < totalPages) {
            showPage(currentPage + 1);
        }
    });
});