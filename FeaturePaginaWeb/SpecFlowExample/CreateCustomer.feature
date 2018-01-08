Feature: SimularCredito
Scenario: SimularCreditoConsumo
Given Ingreso a la pagina principal de Bancolombia
When Lleno los datos
Then verifico Resultadosimulacion


Scenario: GuardarInformacióndelaCuotaTotaldeunCreditodeConsumo
Given Ingreso a la pagina principal de Bancolombia
When Lleno los datos
Then se guarda la informacion de la cuota del credito de consumo en excel

Scenario: SimularCreditoSolucionInmobiliaria
Given Ingreso a la pagina principal de Bancolombia y a la opción de simulador
When Diligenciar información de solución inmobiliaria
Then verifico Resultado Simulacion

Scenario: GuardarInformacióndelaCuotaTotaldeunCreditodeSIM
Given Ingreso a la pagina principal de Bancolombia y a la opción de simulador
When Diligenciar información de solución inmobiliaria
Then Se guarda la informacion de la cuota en excel

