# Clicker Game Development Plan

This document outlines the plan for creating a simple clicker game based on the initial idea.

## Core Components

The game will be built around three main components:

1.  **`StageManager.cs`**: The main game loop and manager.
2.  **`Target.cs`**: The clickable object.
3.  **`EffectObject.cs`**: The visual effect on a successful click.

---

## Class Responsibilities and Implementation Details

### 1. `Target.cs`

-   **Purpose:** Represents the object that the player clicks.
-   **Component:** `MonoBehaviour`.
-   **Requirements:**
    -   Must have a `Collider2D` component to detect clicks.
    -   Could have a `SpriteRenderer` to be visible.
-   **Properties:**
    -   `int maxHealth`: The number of clicks required to destroy the target.
    -   `int currentHealth`: The current health of the target.
-   **Methods:**
    -   `public void OnHit()`: This method will be called by the `StageManager` when the target is successfully clicked. It will decrease `currentHealth`. If `currentHealth` reaches zero, it should notify the `StageManager` (e.g., via an event) that it has been destroyed.

### 2. `EffectObject.cs`

-   **Purpose:** Provides visual feedback to the player when they click the target.
-   **Component:** `MonoBehaviour`.
-   **Prefab:** This script will be attached to a Prefab. The prefab could be a simple sprite with an animation, a particle system, or a UI Text element showing "+1".
-   **Methods:**
    -   `Start()`: On start, it should begin a coroutine to handle its own destruction after a short period (e.g., 1 second). This could include a fade-out animation.

### 3. `StageManager.cs`

-   **Purpose:** Manages the overall game state, including score, target spawning, and input handling.
-   **Component:** `MonoBehaviour`.
-   **Responsibilities:**
    -   **Spawning:**
        -   At `Start()`, it will spawn the first `Target` at a specific position.
        -   When a `Target` is destroyed, it will spawn a new one, perhaps at a random position.
    -   **Input Handling:**
        -   It will use Unity's Input System (`PlayerInput`) to listen for click/tap actions.
        -   On a click event, it will:
            1.  Get the screen position of the click.
            2.  Use `Camera.ScreenToWorldPoint` to convert it to a world position.
            3.  Use `Physics2D.Raycast` to check if any object was hit at that position.
            4.  If the hit object has a `Target` component, it will call the target's `OnHit()` method.
            5.  It will also instantiate the `EffectObject` prefab at the click location.
    -   **Score Management:**
        -   It will keep track of the player's score.
        -   The score should increase on each successful click.
        -   It will interact with a `UIManager` to display the updated score.

### 4. `UIManager.cs` (Optional but recommended)

-   **Purpose:** Manages all UI elements.
-   **Component:** `MonoBehaviour`.
-   **Responsibilities:**
    -   Display the current score.
    -   `public void UpdateScore(int score)`: A method to be called by `StageManager` to update the score display.

---

## Development Workflow

1.  **Create Scripts:** Create the C# scripts: `Target.cs`, `EffectObject.cs`, and `StageManager.cs` in the `Assets/Scripts/Clicker` folder.
2.  **Create Target Prefab:** Create a new GameObject with a `SpriteRenderer` and a `Collider2D`. Attach the `Target.cs` script to it and save it as a prefab.
3.  **Create Effect Prefab:** Create a new GameObject for the click effect (e.g., a "plus" sign sprite). Attach the `EffectObject.cs` script to it and create a prefab. The script should make it fade and disappear.
4.  **Set up the Scene:**
    -   Create an empty GameObject named "StageManager" and attach the `StageManager.cs` script.
    -   Assign the Target and Effect prefabs to the `StageManager` script (via public fields).
    -   Set up the Input Action asset for clicking.
    -   Add a `PlayerInput` component to the `StageManager` GameObject.
    -   Create a UI Text element to display the score and connect it to the `UIManager`.
5.  **Testing:** Play the scene and verify that:
    -   A target appears.
    -   Clicking the target creates an effect and updates the score.
    -   After enough clicks, the target is destroyed and a new one appears.
