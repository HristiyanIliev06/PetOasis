document.addEventListener('DOMContentLoaded', function() {
    const track = document.querySelector('.feedback-track');
    const cards = document.querySelectorAll('.feedback-card');
    const prevBtn = document.querySelector('.prev-btn');
    const nextBtn = document.querySelector('.next-btn');
    
    let currentIndex = 0;
    let startPos = 0;
    let currentTranslate = 0;
    let prevTranslate = 0;
    let isDragging = false;

    const cardWidth = cards[0].offsetWidth + 32; // Including gap
    const maxIndex = cards.length - Math.floor(track.offsetWidth / cardWidth);
    
    function updateSliderPosition(translate = currentIndex * -cardWidth) {
        currentTranslate = translate;
        track.style.transform = `translateX(${translate}px)`;
        
        // Update button states
        prevBtn.style.opacity = currentTranslate >= 0 ? '0.5' : '1';
        nextBtn.style.opacity = currentTranslate <= maxIndex * -cardWidth ? '0.5' : '1';
    }
    
    // Touch events
    function touchStart(event) {
        startPos = event.type.includes('mouse') 
            ? event.pageX 
            : event.touches[0].clientX;
        isDragging = true;
        
        track.style.cursor = 'grabbing';
        track.style.transition = 'none';
    }
    
    function touchMove(event) {
        if (!isDragging) return;
        
        const currentPosition = event.type.includes('mouse')
            ? event.pageX
            : event.touches[0].clientX;
            
        const diff = currentPosition - startPos;
        const translate = prevTranslate + diff;
        
        // Add resistance at the edges
        if (translate > 0 || translate < maxIndex * -cardWidth) {
            currentTranslate = prevTranslate + diff * 0.3;
        } else {
            currentTranslate = translate;
        }
        
        track.style.transform = `translateX(${currentTranslate}px)`;
    }
    
    function touchEnd() {
        isDragging = false;
        const movedBy = currentTranslate - prevTranslate;
        
        track.style.cursor = 'grab';
        track.style.transition = 'transform 0.5s ease';
        
        // If moved more than 100px, change slide
        if (Math.abs(movedBy) > 100) {
            if (movedBy < 0 && currentIndex < maxIndex) {
                currentIndex++;
            } else if (movedBy > 0 && currentIndex > 0) {
                currentIndex--;
            }
        }
        
        updateSliderPosition(currentIndex * -cardWidth);
        prevTranslate = currentIndex * -cardWidth;
    }
    
    // Mouse events
    track.addEventListener('mousedown', touchStart);
    track.addEventListener('mousemove', touchMove);
    track.addEventListener('mouseup', touchEnd);
    track.addEventListener('mouseleave', touchEnd);
    
    // Touch events
    track.addEventListener('touchstart', touchStart);
    track.addEventListener('touchmove', touchMove);
    track.addEventListener('touchend', touchEnd);
    
    // Button controls
    prevBtn.addEventListener('click', () => {
        if (currentIndex > 0) {
            currentIndex--;
            updateSliderPosition(currentIndex * -cardWidth);
            prevTranslate = currentIndex * -cardWidth;
        }
    });
    
    nextBtn.addEventListener('click', () => {
        if (currentIndex < maxIndex) {
            currentIndex++;
            updateSliderPosition(currentIndex * -cardWidth);
            prevTranslate = currentIndex * -cardWidth;
        }
    });
    
    // Prevent context menu on long press
    track.addEventListener('contextmenu', e => e.preventDefault());
    
    // Initialize
    updateSliderPosition();
    
    // Update maxIndex on window resize
    window.addEventListener('resize', () => {
        const newMaxIndex = cards.length - Math.floor(track.offsetWidth / cardWidth);
        if (currentIndex > newMaxIndex) {
            currentIndex = newMaxIndex;
            updateSliderPosition(currentIndex * -cardWidth);
            prevTranslate = currentIndex * -cardWidth;
        }
    });
});
