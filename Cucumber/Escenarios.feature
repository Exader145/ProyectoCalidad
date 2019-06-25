Feature: Escenarios


Background: Testando login
	Given el correo del usario usuario1@correo.com
	And la contraseña 123
	When el usaurio quiera iniciar session
	Then la pagina web redirecionara a vista del usuario con nombre: usuario1

@mytag
Scenario: Background creando playlist
	Given el ususario quiera crear una nueva play list
	When registre la playList con nombre listanuemro1
	Then la web restra la play list y la muestra


