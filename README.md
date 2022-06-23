# MTL
Mail Template Language | A language for creating e-mail templates

Mail Template Language (MTL) is a new alternative to HTML for creating E-mail templates. MTL's syntax is much easier to grasp and easier to write.

See below for a comparison between HTML and MTL.

HTML:
```html
<!doctype html>
<html lang="en-us">
  <head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    
  </head>
  <body>
    <header>
      <img src="images/logo.png" />
    </header>
    <main role="main">
      
    </main>
    <footer>
      <p>Copyright &copy; 2022.</p>
    </footer>
  </body>
</html>
```

MTL:
```
container header {
  image "images/logo.png"
}
container main {
}
container footer {
  text "Copyright &copy; 2022."
}
```
