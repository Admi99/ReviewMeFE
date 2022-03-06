export function AppendStyleSheet(file) {
    //var file = location.pathname.split("/").pop();

    var link = document.createElement("link");
    //link.href = file.substr(0, file.lastIndexOf(".")) + ".css";
    link.href = file;
    link.type = "text/css";
    link.rel = "stylesheet";
    link.media = "screen,print";

    document.getElementsByTagName("head")[0].appendChild(link);
}

window.reviewme_OutsideElementClick = function (elementId, dotnetHelper) {
    window.addEventListener("mousedown", (e) => {
        var element = document.getElementById(elementId);
        if (element != null) {
            if (!document.getElementById(elementId).contains(e.target)) {
                dotnetHelper.invokeMethodAsync("InvokeOutsideElementClick");
            }
        }
    });
}

window.toggleClassFromBody = function (cssClass, force) {
    return document.getElementsByTagName("body")[0].classList.toggle(cssClass, force);
}
