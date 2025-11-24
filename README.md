# 🎲 CodeQuest DLC

## **Capítulo 1: Train your wizard (Entrena tu mago)**

El jugador crea su personaje mago ingresando un nombre. El sistema simula 5 días de entrenamiento donde cada día:
- Se generan horas de entrenamiento aleatorias (1-24)
- Se obtienen puntos de poder aleatorios (1-10)

Al finalizar, según el poder total alcanzado, el mago recibe un título y un mensaje personalizado:
- **< 20 puntos**: "Raoden el Elantrí, Retake in second call."
- **20-29**: "Zyn el Buguejat, You still mix a wand with a spoon."
- **30-34**: "Arka Nullpointer, You are a summoner of magical breezes."
- **35-39**: "Elarion de les Brases, Wow! You can summon dragons without burning down the laboratory!"
- **≥ 40**: "ITB-Wizard el Gris, You have reached the rank of Master of the Arcane!"

### **Juego de pruebas:**

| Caso | Entrada | Salida Esperada | Salida Obtenida | Resultado |
|-----|---------|------------------|-------------------|----------|
| Normal | Nombre: "gandalf" | Nombre formateado: "Gandalf"<br>Entrenamiento completo<br>Título asignado según poder total | Nombre formateado: "Gandalf"<br>Entrenamiento completo<br>Título asignado según poder total | Correcto |
| Límite | Nombre: "a" | Nombre válido: "A"<br>Entrenamiento completo<br>Título asignado según poder total | Nombre válido: "A"<br>Entrenamiento completo<br>Título asignado según poder total | Correcto |
| Error | Nombre: "" (vacío) | Mensaje de error: "Invalid input. Try again"<br>Solicitar nombre nuevamente | Mensaje de error: "Invalid input. Try again"<br>Solicitar nombre nuevamente | Correcto |

---

## **Capítulo 2: Increase LVL (Subir de nivel)**

Sistema de combate contra monstruos aleatorios.
- Aparece un monstruo random con HP específicos
- El jugador tira dados (1-6) hasta que derrota al monstruo
- Cada tirada inflige daño al monstruo
- Al derrotar al monstruo, el mago sube 1 nivel
- Nivel máximo: 5

**Monstruos disponibles**: "Wandering Skeleton 💀", "Forest Goblin 👹", "Green Slime 🟢", "Ember Wolf 🐺", "Giant Spider 🕷️", "Iron Golem 🤖", "Lost Necromancer 🧝‍♂️", "Ancient Dragon 🐉" (Cada uno con su HP)

### **Juego de pruebas:**

| Caso | Entrada | Salida Esperada | Salida Obtenida | Resultado |
|-----|---------|------------------|-------------------|----------|
| Normal | Nivel inicial: 3 | Aparece monstruo aleatorio<br>Combate con dados<br>Level up a nivel 4 | Aparece monstruo aleatorio<br>Combate con dados<br>Level up a nivel 4 | Correcto |
| Límite | Nivel: 5 (máximo) | Mensaje: "You reached the maximum level."<br>No inicia combate | Mensaje: "You reached the maximum level."<br>No inicia combate | Correcto |
| Error | N/A | - | - | Correcto |

---

## **Capítulo 3: Loot the mine (Saquear la mina)**

Minijuego de minería en una cuadrícula 5x5:
- El jugador tiene **5 intentos**
- Ingresa coordenadas X e Y (0-4)
- Si encuentra moneda 🪙, gana bits aleatorios (5-50) y vacía el slot excavado
- Si no hay nada, aparece ❌
- Los bits ganados se acumulan para comprar items

El tablero se actualiza cada vez que entran al minijuego.

### **Juego de Pruebas:**

| Caso | Entrada | Salida Esperada | Salida Obtenida | Resultado |
|-----|---------|------------------|-------------------|----------|
| Normal | X: 2, Y: 3 | Posición minada [2][3]<br>Resultado: 🪙 o ❌<br>Tablero interno y externo actualizado | Posición minada [2][3]<br>Resultado: 🪙 o ❌<br>Tablero interno y externo actualizado | Correcto |
| Límite | X: 4, Y: 4 | Posición válida en esquina [4][4]<br>Resultado mostrado correctamente | Posición válida en esquina [4][4]<br>Resultado mostrado correctamente | Correcto |
| Error | X: 5, Y: 3 | Mensaje: "Invalid input. Try again"<br>Solicitar X nuevamente | Mensaje: "Invalid input. Try again"<br>Solicitar X nuevamente | Correcto |

---

## **Capítulo 4: Show inventory (Mostrar inventario)**

Muestra todos los objetos que el jugador ha comprado en la tienda. Si el inventario está vacío, muestra un mensaje indicándolo.

Simple pero esencial para gestionar los recursos del jugador.

### **Juego de Pruebas:**

| Caso | Entrada | Salida Esperada | Salida Obtenida | Resultado |
|-----|---------|------------------|-------------------|----------|
| Normal | 2 objetos en inventario | Mensaje: "Your inventory contains:"<br>🔸 Item 1<br>🔸 Item 2 | Mensaje: "Your inventory contains:"<br>🔸 Item 1<br>🔸 Item 2 | Correcto |
| Límite | Inventario vacío | Mensaje: "Your inventory is empty" | Mensaje: "Your inventory is empty" | Correcto |
| Error | N/A | - | - | Correcto |

---

## **Capítulo 5: Buy items (Comprar objetos)**

Tienda con 5 objetos disponibles:
1. **Daga de Hierro** 🗡️ - 30 bits
2. **Poción Curativa** ⚗️ - 10 bits
3. **Llave Antigua** 🗝️ - 50 bits
4. **Ballesta** 🏹 - 40 bits
5. **Escudo Metálico** 🛡️ - 20 bits

El jugador puede comprar items si tiene suficientes bits. Los objetos se añaden al inventario y se descuentan los bits gastados.

### **Juego de Pruebas:**

| Caso | Entrada | Salida Esperada | Salida Obtenida | Resultado |
|-----|---------|------------------|-------------------|----------|
| Normal | Bits: 50, Opción: 2 | Compra Poción (10 bits)<br>Bits restantes: 40<br>Item añadido al inventario | Compra Poción (10 bits)<br>Bits restantes: 40<br>Item añadido al inventario | Correcto |
| Límite | Bits: 30, Opción: 1 | Compra Daga (30 bits)<br>Bits restantes: 0<br>Item añadido | Compra Daga (30 bits)<br>Bits restantes: 0<br>Item añadido | Correcto |
| Error | Bits: 5, Opción: 3 | Mensaje: "You don't have enough bits for this purchase..."<br>Sin cambios en el inventario | Mensaje: "You don't have enough bits for this purchase..."<br>Sin cambios en el inventario | Correcto |

---

## **Capítulo 6: Show attacks by LVL (Mostrar ataques por nivel)**

Muestra los ataques disponibles según el nivel actual del mago:
- **Nivel 1**: "Magic Spark 💫"
- **Nivel 2**: "Fireball 🔥", "Ice Ray 🥏", "Arcane Shield ⚕️"
- **Nivel 3**: "Meteor ☄️", "Pure Energy Explosion 💥", "Minor Charm 🎭", "Air Strike 🍃"
- **Nivel 4**: "Wave of Light ⚜️", "Storm of Wings 🐦"
- **Nivel 5**: "Cataclysm 🌋", "Portal of Chaos 🌀", "Arcane Blood Pact 🩸", "Elemental Storm ⛈️"

Se usa un jagged array ya que cada nivel tiene una cantidad diferente de ataques.

### **Juego de Pruebas:**

| Caso | Entrada | Salida Esperada | Salida Obtenida | Resultado |
|-----|---------|------------------|-------------------|----------|
| Normal | Nivel: 3 | Mensaje: "Available attacks for level 3"<br>4 ataques mostrados (Meteor ☄️, Pure Energy Explosion 💥, Minor Charm 🎭, Air Strike 🍃) | Mensaje: "Available attacks for level 3"<br>4 ataques mostrados (Meteor, Explosion, Charm, Air Strike) | Correcto |
| Límite | Nivel: 1 | Solo 1 ataque: Magic Spark 💫 | Solo 1 ataque: Magic Spark 💫 | Correcto |
| Error | N/A | - | - | Correcto |

---

## **Capítulo 7: Decode ancient Scroll (Decodificar pergamino antiguo)**

Ejercicio de manipulación de strings con 3 pergaminos encriptados:

1. **Descifrar hechizo** (eliminar espacios): Procesa el texto del dragón
2. **Contar runas mágicas** (contar vocales): Analiza las cuevas de cristal
3. **Extraer código secreto** (extraer números): Obtiene números del hechizo elemental

Curiosidad `\"` te añade comillas dentro de un string.

Al completar los 3 desafíos, el jugador recibe un mensaje de felicitación. Sistema de seguimiento con array booleano `decodedScrolls` (Si los 3 son true aparece el mensaje).

### **Juego de Pruebas:**

| Caso | Entrada | Salida Esperada | Salida Obtenida | Resultado |
|-----|---------|------------------|-------------------|----------|
| Normal | Opción: 2 | Conteo de vocales en scroll 2<br>Mensaje: "12 magical runes (vowels) found"<br>decodedScrolls[1] = true | Conteo de vocales en scroll 2<br>Mensaje: "12 magical runes (vowels) found"<br>decodedScrolls[1] = true | Correcto |
| Límite | Completar 3 scrolls | Después del tercero:<br>Mensaje : "Congratulations! You have successfully decoded all parts of the scroll." | Después del tercero:<br>Mensaje: "Congratulations! You have successfully decoded all parts of the scroll." | Correcto |
| Error | Opción: 5 | Mensaje: "Invalid input. Try again"<br>Solicitar opción nuevamente | Mensaje: "Invalid input. Try again"<br>Solicitar opción nuevamente | Correcto |
