# pedestrian-crossing-ai
Train AI Pedestrian Agents to cross a busy street without being hit using Machine Learning!

## Setup
### Prerequisites
The Project was created in the <a href="https://unity.com/">Unity game engine</a>, utilising <a href="https://www.python.org/downloads/">Python</a>, <a href="https://pytorch.org/get-started/locally/">PyTorch</a>, and <a href="https://github.com/Unity-Technologies/ml-agents/releases">ML-Agents</a>. Please see the respective documentation pages for specific installation/setup instructions.

### Training of the Agents
To train the agents, run: ```mlagents-learn --run-id=<unique-id>``` in a terminal of choice. Then, once listening, start the project within Unity:

Upon completion of the training, a <a href="https://onnx.ai/">.onnx</a> file will be generated with the model, which can be added to the _Model_ field of the agent within Unity.

## Results
### Agents with Minimal Training
With only minimal training, the agents have begun to move towards the **goal** (the other side of the street), but they **do not yet avoid vehicles**.
![AI agents moving towards the goal but not avoiding vehicles](Docs/MinimalTraining.gif)

## Extended Training
With additional training, the agents **efficiently reach the goal while successfully navigating around the moving vehicles**.
![AI agents successfully avoiding vehicles and crossing the street](Docs/FurtherTraining.gif)
