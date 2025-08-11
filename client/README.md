# React + TypeScript + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react) uses [Babel](https://babeljs.io/) for Fast Refresh
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh

## Expanding the ESLint configuration

If you are developing a production application, we recommend updating the configuration to enable type-aware lint rules:

```js
export default tseslint.config([
  globalIgnores(['dist']),
  {
    files: ['**/*.{ts,tsx}'],
    extends: [
      // Other configs...

      // Remove tseslint.configs.recommended and replace with this
      ...tseslint.configs.recommendedTypeChecked,
      // Alternatively, use this for stricter rules
      ...tseslint.configs.strictTypeChecked,
      // Optionally, add this for stylistic rules
      ...tseslint.configs.stylisticTypeChecked,

      // Other configs...
    ],
    languageOptions: {
      parserOptions: {
        project: ['./tsconfig.node.json', './tsconfig.app.json'],
        tsconfigRootDir: import.meta.dirname,
      },
      // other options...
    },
  },
])
```

You can also install [eslint-plugin-react-x](https://github.com/Rel1cx/eslint-react/tree/main/packages/plugins/eslint-plugin-react-x) and [eslint-plugin-react-dom](https://github.com/Rel1cx/eslint-react/tree/main/packages/plugins/eslint-plugin-react-dom) for React-specific lint rules:

```js
// eslint.config.js
import reactX from 'eslint-plugin-react-x'
import reactDom from 'eslint-plugin-react-dom'

export default tseslint.config([
  globalIgnores(['dist']),
  {
    files: ['**/*.{ts,tsx}'],
    extends: [
      // Other configs...
      // Enable lint rules for React
      reactX.configs['recommended-typescript'],
      // Enable lint rules for React DOM
      reactDom.configs.recommended,
    ],
    languageOptions: {
      parserOptions: {
        project: ['./tsconfig.node.json', './tsconfig.app.json'],
        tsconfigRootDir: import.meta.dirname,
      },
      // other options...
    },
  },
])
```
client -> package.json
dependencies: {
"react": "^latest version"
}
- note: make sure you run npm commands in the client folder and not in the outside of the client folder
- npm install
> inside the index.html
title>Reactivities</title>
> inside the App.tsx
--> remove all the html
<h3>Reactivities</h3>
--> index.css
--> remove all of these things

> extension: 
react: ES7+ React/Redux/React-Native snippets
ESLint 

> writing in jsx file:
< style = {{}}>

const [] = useState([]);
useEffect(()=>{
	fetch('https://localhost:5001/api/activities').then(
reponse=> response.json()).then(data=> setActivities(data))
return ()=> {}
}, []);

return(<div>
<h3 className="app" style{{color: red}}>Reactivities</h3>
<ul>{activities.map((activity)=>(<li>{activity.title}</li>))}</ul>
</div>)

------------

CORS: Cross origin resource sharing. How resources are accessed securely so that different origins can access them. No access-controll-allow-origin header is present on the requested resource --> 
> Go to Program.cs to set up the CORS. Now services dont have to have a specific order. After AccDbContext<AppDbContext>() :
builder.Services.AddCors();
Middleware is specific about the order though, so it is important to do the right order here. BEFORE MapControllers():
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000", "https://localhost:3000"));
CTRL+R

-Run API: dotnet watch 
-Run client: npm run dev

- Format: ALT + SHIFT + F

material UI installation via their website>installation:
npm install @mui/material @emotion/react @emotion/styled

>install the roboto font: 
add the below to make sure that there is: 
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';

- install material UI design

-mkcert installation. Check github pages of it

-axious: npm install axious
-axious has some advantages over fetch(). Check axious features.
-automatic json handling, 

-Clean Architecture
- independant from frameworks, inteerface, db
- testable
-CQRS: Command query responsibility segregation
-- commands: that update db in some way
-- queries: reads data from db
-- mediator: mediates between different layers in clean acrchitecture

Step1: Go to Nuget and download: MediiatR @Jimmy Bogard to our APPLICATION project
- Used to create handlers in our project

-Hot reload can let ya down so CTRL+R that API dotnet server
