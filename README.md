[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/7Wj0oCgF)

# RL Project 2 - Unity RL Agent

## André Tavernaro

O objetivo deste projeto é utilizar Reinforcement Learning em conjunto com a Unity para desenvolver um agente que é capaz de escapar de uma sala com alguns obstaculos e desafios. Para isso, será utilizada a biblioteca [Unity Machine Learning Agents](https://unity.com/products/machine-learning-agents).

Segue um link para um vídeo de referência feito pelo canal [AIWarehouse](https://www.youtube.com/watch?v=v3UBlEJDXR0), no qual o autor desenvolveu um projeto praticamente igual ao proposto. 

![Alt text](Images/example.png?raw=true)

# Metodologia

## Descrição

O agente foi treinado em 2 ambientes distintos, mostrados nas imagens abaixo. O objetivo é passar pela porta à direita, porém para isso, ele deve apertar o botão azul no chão antes (para apertar ele só precisa passar em cima), além disso ele não pode encostar em nenhuma parede.

![Alt text](Images/env.png?raw=true "Ambiente 1")

![Alt text](Images/env2.png?raw=true "Ambiente 2")

![Alt text](Images/env3.png?raw=true "Ambiente 3")

## Action Space

O agente é somente capaz de Andar, no eixo x e no eixo z. Logo, ele possui 2 ações contínuas, que são representadas por um float.

| Ação                       | Valor min       | Valor max      |
| -------------------------- | --------------- | -------------- |
| mover no eixo X            | -1              | 1              |
| mover no eixo Y            | -1              | 1              |

Outra ação disponível indiretamente é pressionar um botão no chão, o botão é acionado ao andar com o agente sobre o botão. Os botões quando pressionados abrem portas. 

## Observation Space

O observation neste caso consiste em vetores de tamanho 3 com posições de GameObjects no ambiente.

| Observation                | Tipo      | 
| -------------------------- | --------- | 
| posição do agente          | Vector3   |
| posição da saída           | Vector3   |

## Recompensas

- +999 por conseguir escapar da sala
- +20 por pressionar o botão
- -(distância da saida - distância do agente) por encostar em qualquer parede
- -((distância da saida - distância do agente) * 0.0001f) por cada ação de movimento

## Início do episódio

No início de cada episódio, o agente é colocado em sua posição inicial, e a porta volta a ficar ativa.

## Fim do episódio

O episódio acaba se o agente chegar na saída ou se enconstar em alguma parede.

## Treinamento

No treinamento, foram utilizados 16 cópias identicas do ambiente, cada uma delas com seu agente, isso acelerou o tempo de treinamento já que 16 agentes estavam treinando ao mesmo tempo. Lembrando que para cada ambiente foi feito um treinamento individual para aquele ambiente.

![Alt text](Images/16env.png?raw=true)

Para facilitar a visualização do treinamento, quando o agente atinge seu objetivo, o chão em que ele anda fica verde, e quando ele falha ao atingir uma parede, o chão fica vermelho, isso pode ser visto no gif abaixo:

![Alt text](Images/RL-train.gif?raw=true)


## Algoritmo e hiperparâmetros usados para treinamento

| Atribute                   | Value           |
| -------------------------- | --------------- |
| Algorithm                  | ppo             |
| batch_size                 | 1024            |
| learning_rate              | 0.0003          |
| beta                       | 0.005           |
| epsilon                    | 0.9             |
| lambd                      | 0.95            |
| gamma                      | 0.99            |
| max_steps                  | 5000            |
| episodes                   | 500000          |

# Resultados

Abaixo temos um gráfico de rewards e em seguida um gráfico de duração de episódio, ambos no ambiente 1:

![Alt text](Images/rewards_1.png?raw=true)

![Alt text](Images/duracao_1.png?raw=true)

Abaixo temos um gif do modelo treinado em ação no ambiente 1:

![Alt text](Images/RL-model.gif?raw=true)

Abaixo temos um gráfico de rewards e em seguida um gráfico de duração de episódio, ambos no ambiente 2:

![Alt text](Images/rewards2_1.png?raw=true)

![Alt text](Images/duracao2_1.png?raw=true)

Abaixo temos um gif do modelo treinado em ação no ambiente 2:

![Alt text](Images/RL-model2.gif?raw=true)

Abaixo temos um gráfico de rewards e em seguida um gráfico de duração de episódio, ambos no ambiente 3:

![Alt text](Images/rewards3.png?raw=true)

![Alt text](Images/duracao3.png?raw=true)

Abaixo temos um gif do modelo treinado em ação no ambiente 3:

![Alt text](Images/RL-model3.gif?raw=true)

Abaixo temos um gráfico de rewards e em seguida um gráfico de duração de episódio, comparando o desempenho nos 3 ambientes: 
- verde = ambiente 1
- laranja = ambiente 2
- cinza = ambiente 3

![Alt text](Images/rewards-comp.png?raw=true)

![Alt text](Images/duracao-comp.png?raw=true)

## Tutorial de instalação

A setup inicial pode ser um pouco difícil e chato, felizmente existe um ótimo [vídeo](https://youtu.be/zPFU30tbyKs) que ensina como instalar tudo corretamente. No entanto, o vídeo está um pouco desatualizado, então vou deixar aqui as etapas que você deve fazer diferente para deixar tudo certo.

Se você tiver problemas com o comando "mlagents-learn --help", tente os seguintes passos:

1. Desinstale seu python
2. Instale o python 3.8.10
3. Crie e ative o seu env (como ele faz no vídeo)
4. Atualize o pip (como ele faz no vídeo)
5. Rode o seguinte comando: "pip3 install torch~=1.7.1 -f https://download.pytorch.org/whl/torch_stable.html"
6. Rode o seguinte comando: "pip install mlagents"
7. Tente novamente o comando: "mlagents-learn --help"
8. Se não funcionar (o meu não funcionou), rode o seguinte comando: "pip install protobuf==3.20.3"
9. Tente novamente o comando: "mlagents-learn --help"
