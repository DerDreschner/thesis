function copyToClipboard(elementId, message) {
    var textToCopy = document.getElementById(elementId);
    textToCopy.select();
    document.execCommand("copy");
    alert(message);
    return false;
}