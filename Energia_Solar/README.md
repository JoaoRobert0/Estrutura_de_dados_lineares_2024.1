Existe um número de casas em uma rua. Cada casa tem uma planta de geração de
energia solar. Casas disponíveis(não entraram em uma linha de força ainda) com valores mais altos
de produção de energia em relação sua a esquerda não podem ficar na mesma
linha de transmissão, pois isso pode provocar uma sobrecarga nessa
linha. É dado o valor da produção de cada casa. Crie um programa que
aloque as casas em um número de linhas de força necessárias para que não
haja sobrecarga na rua. Faça as verificações da esquerda para a direita.

Ex1.:

P={3, 6, 2, 7, 5} // produção das casas em uma rua

Passo 1 - Determinar casas da primeira linha de força
linha de força 1 - {6,2,5}


Passo 2 - Determinar casas da segunda linha de força
Linha de força 2 - {7}


Passo 3 - Determinar casas da terceira linha de força
Linha de força 3 - {3}

Nesse exemplo, foram necessárias 3 linhas de força para resolver o problema da rua P.

Ex2.:

P={8,6,10,4,1,5,3} // produção das casas em uma rua

Passo 1 - Determinar casas da primeira linha de força
linha de força 1 - {8,6,4,1,3}


Passo 2 - Determinar casas da segunda linha de força
Linha de força 2 - {10,5}


Nesse exemplo, foram necessárias 2 linhas de força para resolver o problema da rua P.

OBS.: UTILIZE A ESTRUTURA DE DADOS PILHA
PARA SOLUCIONAR ESSE PROBLEMA

(DESENVOLVA UMA VERSÃO COM ARRAY, UTILIZANDO A ESTRATÉGIA DE DUPLICAÇÃO
EM CASO DE ENCHIMENTO DO ARRAY E CASO O ARRAY CHEGUE ATÉ 25% DE OCUPAÇÃO ,
O MESMO, DEVE SER REDUZIDO PELA METADE ). SUA NOTA DEPENDERÁ DA SUA
IMPLEMENTAÇÃO E USO CORRETO DA PILHA NA SOLUÇÃO DO PROBLEMA.

OBS.: O CÓDIGO DEVE SER IDENTADO, FONTES MONOESPAÇADAS E USAR AS CORES DAS PRINCIPAIS IDES, ENTREGAR UM ARQUIVO WORD COM CÓDIGO.