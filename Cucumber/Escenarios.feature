Feature: Escenarios

@mytag
Scenario: Testeando Login para el usuario
	Given el correo del usario
	And la contraseña
	When el usaurio quiera iniciar session
	Then la interfaz de la web cambiara a la pagina inicio del usuario: 
