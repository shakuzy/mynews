# mynews

Buenas, Este proyecto consiste en un portal de noticias que realice en la carrera "Full-stack Net Developer",
 este sistema esta desarrollado en C# ASP .NET CORE MVC, ENTITY FRAMEWORK CORE(code first), 

EF IDENTITY(para los roles y autorización), LINQ(consultas), SQLSERVER(base de datos), utilice BOOTSTRAP Y CSS3(para el diseño), para las estructuras de las RAZOR PAGES utilice HTML5, HTML HELPERS Y TAG HELPERS. 
Este sistema ofrece la oportunidad de tener varios roles, los cuales son 3 que serian: SuperAdmin, Admin, User. 
El User a diferencia del usuario anónimo tiene la posibilidad de comentar en las noticias del sistema, el Admin puede hacer lo mismo que el user pero también puede agregar, borrar y editar los post, también cuenta con la posibilidad de borrar comentarios. y por último el SuperAdmin cuenta con las mismas posibilidades que el Admin pero puede editar(nombre de usuario y rol) y borrar usuarios

Bueno ahora vamos con las pantallas...


En este primer video podemos ver como lo miraran la mayoría de las personas que no esten registradas, que solamente podrán visualizar las noticias mediante la pantalla Home Y también filtrarlos por categoría, pero no podrán comentar las publicaciones.

https://user-images.githubusercontent.com/56520398/141230566-c3599c8e-ea73-4d1d-86a2-0f9fe9bb01a1.mp4

Acá se muestra como registrarse poniendo en el sistema, el nombre de usuario, el mail y la contraseña confirmada para poder comentar

https://user-images.githubusercontent.com/56520398/141230675-cd9f6492-9847-4b24-a4fc-183356535676.mp4

En el siguiente video sé podra ver la pantalla que va a ver el administrador, el cual este puede agregar post, editarlo y borrarlo. También tiene la posibilidad de borrar los comentarios que crea conveniente y también borrar todos los comentarios de una sola vez.

https://user-images.githubusercontent.com/56520398/141230960-3ada4129-a216-4560-8787-5d82e7b4891a.mp4

En esta pantalla se puede ver todos los datos que el sistema pide para agregar una noticia: Imagen, Titulo, Resumen, Cuerpo, Fecha, Categoría, Autor

https://user-images.githubusercontent.com/56520398/141231038-32e44fad-baa7-4c0e-9b62-b75a5b2225e6.mp4

Luego se muestra como quedaría en el sistema una vez agregado

https://user-images.githubusercontent.com/56520398/141231103-999db1c1-1af4-425f-b0bf-9601dba65dd5.mp4

En este ultimo video se muestra desde la perspectiva del SuperAdmin que tiene las mismas posibilidades que el Admin, pero ademas cuenta con la posibilidad de manipular los usuarios del sistema, Como por ejemplo cambiar su Username y también su rol. Como también poder eliminarlo completamente

https://user-images.githubusercontent.com/56520398/141231247-ae704338-4b39-4e19-9de0-48537babaa34.mp4

Bibliografía:

-ASP .NET CORE: https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022
-EF CORE: https://docs.microsoft.com/en-us/ef/core/
-EF IDENTITY: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-6.0
-LINQ: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
-SQLSERVER: https://www.microsoft.com/en-us/sql-server/sql-server-2019
-BOOTSTRAP: https://getbootstrap.com
