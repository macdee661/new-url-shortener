document.getElementById('urlForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    
    const longURL = document.getElementById('longURL').value;
    if (!longURL) {
        alert("Please enter a valid URL.");
        return;
    }

    try {
        const response = await fetch(`http://localhost:5264/addURL?longURL=${encodeURIComponent(longURL)}`);
        const data = await response.json(); // Change to json since we're returning an object
        
        if (!response.ok) {
            throw new Error(data || "URL shortening failed");
        }

        // Create or show result div for the shortened URL
        const resultDiv = document.getElementById('shortenedResult') || createResultDiv();
        resultDiv.innerHTML = `
            <div class="p-4 border rounded mt-4">
                <p>Your shortened URL:</p>
                <div class="flex items-center gap-2">
                    <input type="text" 
                           value="${data.shortURL}" 
                           readonly 
                           class="border p-2 flex-grow"
                           id="shortURLResult">
                    <button onclick="copyToClipboard('shortURLResult')" 
                            class="px-4 py-2 bg-blue-500 text-white rounded">
                        Copy
                    </button>
                </div>
            </div>
        `;

    } catch (error) {
        alert("An error occurred: " + error.message);
    }
});

// Helper function to create the result div if it doesn't exist
function createResultDiv() {
    const div = document.createElement('div');
    div.id = 'shortenedResult';
    document.getElementById('urlForm').after(div);
    return div;
}

// Helper function to copy text to clipboard
function copyToClipboard(elementId) {
    const element = document.getElementById(elementId);
    element.select();
    document.execCommand('copy');
    window.getSelection().removeAllRanges();
}

// Keep the getShortURLForm event listener as is since it's already showing results in a good format
document.getElementById('getShortURLForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    
    const shortURL = document.getElementById('shortURLInput').value;
    if (!shortURL) {
        alert("Please enter a valid short URL.");
        return;
    }

    try {
        const response = await fetch(`http://localhost:5264/getURL?shortURL=${encodeURIComponent(shortURL)}`);
        const data = await response.text();
        
        if (!response.ok) {
            throw new Error(data || "URL retrieval failed");
        }

        document.getElementById('result').style.display = 'block';
        document.getElementById('fullURL').textContent = data;

    } catch (error) {
        alert("An error occurred: " + error.message);
    }
});