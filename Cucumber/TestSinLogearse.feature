Feature: TestSinLogearse
	

@mytag2
Scenario: Testeando registro del usuario
	Given el usuario no este logeado
	And el nombre del usuario juan, su correo para ingresar nuevo@correo.com y su contraseña 123
	When el usaurio quiera registrarse en SpotiFake
	Then la pagina web redirecionara a vista del usuario con nombre: juan