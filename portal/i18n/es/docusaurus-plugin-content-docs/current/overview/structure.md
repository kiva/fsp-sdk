---
sidebar_position: 2
---

# Estructura de la integración

La API de Kiva está diseñada para conectar el SIG de un socio directamente con PA2. Puede utilizarse para publicar automáticamente los préstamos o reportar los reembolsos. Las principales ventajas de utilizar la API son el ahorro de tiempo de los socios y la mejora en la precisión de la información introducida en PA2.

A continuación se presenta un esquema básico de lo que hay que completar para integrarse con la API de Kiva:

1. __Actualización__ del SIG para enviar información a los puntos finales de Kiva en formato JSON. La API de Kiva está configurada como un punto final que acepta datos en un formato específico utilizando JSON. Para comenzar a utilizar nuestra API, el socio debe configurar su SIG para enviar información al punto final de Kiva en este formato.
2. __Autenticación__ del SIG en el cliente de la API de Kiva. Kiva utiliza un token OAuth2 para la autenticación. Tenga en cuenta que tendrá que crear un sistema que solicite automáticamente un token a Kiva y se autentique con una cadencia de 12 horas.
3. __Comprobación__ de la conexión con la API mediante el envío de borradores de préstamos y reportes de reembolsos a PA2 para que Kiva los revise.
4. __Capacitación__ dirigida al coordinador de Kiva sobre cómo utilizar la API
5. Después de que sus pruebas sean verificadas por Kiva, cambie sus credenciales para comenzar a publicar directamente en PA2.

## Opciones de estructuración de la integración

Kiva ha creado una API REST. Para que pueda utilizar la API, debe desarrollar una integración que pueda enviar una post request a una URL específica con información en el formato JSON que hemos indicado a continuación. Hay muchas maneras diferentes de estructurar esto dependiendo de su SIG y de cómo almacena los datos de los préstamos. Aquí hay algunas ideas sobre cómo podría estructurarse:

* Si tiene control sobre el código de su SIG, puede editar el código de su SIG directamente y conectarlo a la API.
* Si su SIG tiene un complemento de plug-in, puede crear un plug-in para enviar los datos JSON a la API de Kiva.
* Si tiene un servidor SQL u otro tipo de base de datos y desea conectarla a la API de Kiva en lugar de a su SIG, puede crear una aplicación independiente que envíe los datos en formato JSON directamente a la API de Kiva.
* Si tiene una base de datos de Excel, una macro podría traducirla a formato JSON y enviar la información a la API de Kiva.

Queremos proporcionar a su equipo técnico algo de información sobre los tres procesos que la API automatizará. Puede encontrar información sobre los informes de reembolso, el proceso de creación de borradores de préstamos individuales y de grupo y el registro de seguimientos en esta sección del Centro de Asistencia para socios. También recomendamos que su equipo técnico consulte con el coordinador de Kiva en su organización para comprender plenamente estos procesos de Kiva.