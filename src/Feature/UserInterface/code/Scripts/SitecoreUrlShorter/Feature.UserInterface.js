function copyToClipboard(elementId) {
    var textToCopy = document.getElementById(elementId);
    textToCopy.select();
    document.execCommand("copy");
    alert("Copied the text: " + textToCopy.value);
    return false;
}