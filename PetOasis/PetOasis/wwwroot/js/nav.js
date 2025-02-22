// Set active nav link based on current URL
document.addEventListener('DOMContentLoaded', function() {
    const currentPage = window.location.pathname.split('/').pop() || 'base.html';
    const navLinks = document.querySelectorAll('.nav ul li a');
    
    navLinks.forEach(link => {
        // Remove any existing active class
        link.classList.remove('active');
        
        // Add active class only if the href matches the current page
        if (link.getAttribute('href') === currentPage) {
            link.classList.add('active');
        }
    });
});
