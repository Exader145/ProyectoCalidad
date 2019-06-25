Feature: Escenarios

@mytag
Scenario: Testeando Login
	Given el correo del usario usuario1@correo.com
	And la contraseña 123
	When el usaurio quiera iniciar session
	Then la pagina web redirecionara a vista del usuario con nombre: usuario1
