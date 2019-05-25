function copyToClipboard(elementId) {
    var textToCopy = document.getElementById(elementId);
    textToCopy.select();
    document.execCommand("copy");
    textToCopy.unselect();
    alert("Copied the text: " + textToCopy.value);
    return false;
}