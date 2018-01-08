Feature: SimularCredito
Scenario: SimularCreditoConsumo
Given Ingreso a la pagina principal de Bancolombia
When Lleno los datos
Then verifico Resultadosimulacion


Scenario: SimularCreditoSolucionInmobiliaria
Given Ingreso a la pagina principal de Bancolombia y a la opción de simulador
When Diligenciar información de solución inmobiliaria
Then verifico Resultado Simulacion


