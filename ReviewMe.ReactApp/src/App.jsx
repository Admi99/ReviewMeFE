import React, { useEffect } from "react";
import { Navbar, Sidebar } from "./components";
import "./style.css";

const applicationUrl = "https://localhost:5001";
const applicationRootElementId = "app"; // TODO: Pass this parameter to blazor app to use as a root element

function App() {
  const token =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6NDksImZpcnN0TmFtZSI6IlRvbcOhxaEiLCJsYXN0TmFtZSI6Ikp1xZlpxI1rYSIsImZ1bGxOYW1lIjoiVG9tw6HFoSBKdcWZacSNa2EiLCJhZG1pbiI6ZmFsc2UsInNlY3VyZSI6ImgxOE03ZkhoSHlpZldqOFRicVZ0IiwibG9naW4iOiJqdXJpY2thIiwiaWF0IjoxNjM5MTMwNTg1fQ.BkBKaik1qOrEV1P4pqcC9U2e5wGEZqDdpYTWmZB22q0";
  localStorage.setItem("jwtToken", token);

  function NotificationHandler(message, type, timeout) {
    return alert(`${type}: ${message} (timeout: ${timeout})`);
  }

  useEffect(() => {
    loadAndStartBlazorApp(applicationUrl);
  }, []);

  // Loads and stars the blazor app from specified url
  function loadAndStartBlazorApp(url) {
    fetch(`${url}/_framework/blazor.webassembly.js`)
      .then((response) => response.text())
      .then((scriptContent) =>
        addApplicationUrlToScriptContent(scriptContent, url)
      )
      .then((scriptContent) => appendScriptElement(scriptContent))
      .then((_) => startBlazor(url));
  }

  // Appends application url to some parts of the initial script
  // Dirty hack because the aspnetcore has the support of such feature still in backlog
  function addApplicationUrlToScriptContent(scriptContent, url) {
    return scriptContent
      .replace(
        "_framework/blazor.boot.json",
        `${url}/_framework/blazor.boot.json`
      )
      .replace("fetch(e,{method:", `fetch("${url}/" + e, { method:`);
  }

  // Adds a script element and sets autostart to false
  function appendScriptElement(scriptContent) {
    const scriptElement = document.createElement("script");
    scriptElement.async = true;
    scriptElement.crossOrigin = true;
    scriptElement.setAttribute("autostart", false);
    scriptElement.text = scriptContent;
    document.body.appendChild(scriptElement);
  }

  // Starts the blazor and overrides the url of some of the resources that it will load
  function startBlazor(url) {
    window.Blazor.start({
      loadBootResource: function (type, name, defaultUri, integrity) {
        console.log(
          `Loading: '${type}', '${name}', '${defaultUri}', '${integrity}'`
        );
        return defaultUri.indexOf("_framework") !== -1
          ? `${url}/_framework/${name}`
          : `${url}/${name}`;
      },
    })
      .then(console.log("Blazor app loaded"))
      .then((_) => {
        const ref = window.DotNet.createJSObjectReference({
          NotificationHandler,
        });

        window.DotNet.invokeMethod("ReviewMe.Frontend", "AttachHandler", ref);
      });
  }

  return (
    <>
      <Navbar />
      <Sidebar />
      <main className="main">
        <div id={applicationRootElementId}></div>
      </main>
    </>
  );
}

export default App;
