---
sidebar_position: 1
---

# Overview of Kiva's API

## ¿Qué hace la API de Kiva?
La API de Kiva es una herramienta que puede conectar el SIG de un socio directamente con PA2. Puede utilizarse para publicar automáticamente los préstamos o informar de los reembolsos.

* Publicación de préstamos: Un SIG suele almacenar el nombre del prestatario, el sexo, el ID del cliente, el ID del préstamo, el monto del préstamo, la fecha de desembolso y el calendario de reembolso. Para publicar un nuevo préstamo en Kiva, debe introducir manualmente toda esta misma información en PA2. Utilizando la API, el SIG puede enviar esta información directamente a PA2 y crear un nuevo borrador de préstamo. En lugar de introducir manualmente toda la información para un nuevo préstamo, ahora solo tiene que revisar el borrador y publicarlo.
* Reporte de reembolsos: La información de reembolsos actualizada de cada prestatario se almacena en el SIG. Con la API, esta información puede enviarse directamente a PA2 cada mes, lo que elimina la necesidad de crear y cargar manualmente un archivo CSV.A continuación, el socio debe revisar y finalizar su reporte como lo haría normalmente.
* Publicación de seguimientos: La información de un nuevo seguimiento o cualquier actualización que esté almacenada en el SIG de un socio puede enviarse directamente a PA2 a través de la API en lugar de cargarse manualmente. El socio tendrá que revisar y confirmar todos los seguimientos enviados desde su sistema interno. Ventajas del uso de la API de Kiva

## Beneficios de usar la API de Kiva
Las principales ventajas de utilizar la API son:

* Ahorro de tiempo para los socios. Dado que la API de Kiva reduce la cantidad de información que hay que introducir manualmente en PA2, se ahorrará el tiempo que antes se dedicaba a ello.
* Mejora en la precisión de la información introducida en PA2. La introducción manual de datos es propensa a los errores humanos. Con la API, la información en PA2 puede coincidir exactamente con la información en el SIG del socio.

## Testimonios de los socios

Kiva puso a prueba la API con Milaap, uno de nuestros socios que opera en la India, con resultados muy positivos. Redujeron el tiempo necesario para publicar un perfil de 10 a 12 minutos a sólo 4 minutos. Milaap tardó unas dos semanas en configurar y probar la API. Esto es lo que dijeron en sus propias palabras: 

> "La creación de la API ha reducido considerablemente el tiempo y el esfuerzo que dedicamos a la carga de perfiles... Esto nos ha permitido recaudar más fondos en menos tiempo. Además, también se liberan algunos recursos humanos, que ahora pueden dedicarse a otras actividades”.


## ¿Cómo puedo empezar a usar la API de Kiva?

La API de Kiva está configurada como un punto final que acepta datos en un formato específico utilizando JSON. Para empezar a utilizar nuestra API, el socio de campo debe configurar su SIG para enviar información al punto final de Kiva en este formato.

Si está interesado en integrarse, por favor, rellene este [formulario](https://kiva.tfaforms.net/111).
