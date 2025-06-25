window.playPlim = () => {
  const audio = document.getElementById("plimSound");
  if (audio) {
    audio.currentTime = 0;
    audio.play();
  }
};