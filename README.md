[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/7Wj0oCgF)

# RL Project 2 - Unity RL Agent

## André Tavernaro

O objetivo deste projeto é utilizar Reinforcement Learning em conjunto com a Unity para desenvolver um agente que é capaz de escapar de uma sala com alguns obstaculos e desafios. Para isso, será utilizada a biblioteca [Unity Machine Learning Agents](https://unity.com/products/machine-learning-agents).

Segue um link para um vídeo de referência feito pelo canal [AIWarehouse](https://www.youtube.com/watch?v=v3UBlEJDXR0), no qual o autor desenvolveu um projeto praticamente igual ao proposto. 

![Alt text](Images/example.png?raw=true)

## Action Space

O agente é somente capaz de Andar, no eixo x e no eixo z.

Outra ação disponível indiretamente é pressionar um botão no chão, o botão é acionado ao andar com o agente sobre o botão. Os botões quando pressionados abrem portas. 

## Tutorial

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

## Resultados

O agente foi treinado no ambiente mostrado na imagem abaixo, seu objetivo era passar pela porta à direita, porém para isso, ele deve apertar o botão azul no chão antes (para apertar ele só precisa passar em cima).

![Alt text](Images/env.png?raw=true)

Abaixo está um gif do processo de treinamento:

![Alt text](Images/train.gif?raw=true)

Abaixo estão 2 gráficos obtidos no tensorboard:

- Cumulative Reward

![Alt text](Images/rewards.png?raw=true)

- Episode Length

![Alt text](Images/duracao.png?raw=true)

Abaixo está um gif do modelo treinado em ação:

![Alt text](Images/model.gif?raw=true)