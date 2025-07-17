// export function setTheme(isDark) {
//   document.body.classList.toggle('dark-mode', isDark);
// }

export function setTheme(isDark) {
    const body = document.body;
    
    if (isDark) {
        body.classList.add("dark");
    } else {
        body.classList.remove("dark");
    }
}


// ainda não mudei nada do que você disse nesse ultimo comentário, mas o erro que está dando ao clicar no botão de mudar o tema é o seguinte 