setTimeout(() => {
    const header = document.getElementsByClassName('css-1dbjc4n r-1d09ksm r-18u37iz r-1wbh5a2');
    console.log(header.length);
    for (let item of header) {
        let status = document.createElement('span');
        status.innerHTML = "Neutral";
        status.setAttribute("class", "unknown-status");
        // CSS Styling Neutral
        status.style.padding  = '5px 10px 5px 10px';
        status.style.marginLeft = "10px";
        status.style.borderRadius = "25px";
        status.style.backgroundColor = "#657786";
        status.style.color = "#ffffff";
        // CSS Styling Neutral
        item.appendChild(status);
    }
}, 2000);


