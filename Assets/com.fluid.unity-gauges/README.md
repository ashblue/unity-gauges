# Unity Gauges

A simple utility script for creating gauges to maintain stats such as health, energy, stamina, ect.

* Allows you to set a min, max, and value range
* Helper methods such as `IsEmpty` and `ChargePercent` to quickly analyze data
* Emits events when the value changes to sync UIs, remove characters, update AI, ect.
* Written with tests and interfaces for TDD

## Example Usage

Unity Gauge is a light implementation with no dependencies. The creation is class based and does not require a MonoBehavior.

The below example creates a health bar that could be attached to a character. With the `_onChange` event you can easily makes health changes modify a connected character.

```c#
using CleverCrow.Fluid.Gauges;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExampleHealthBar : MonoBehaviour {
    private readonly Gauge _health = new Gauge(10);

    [SerializeField]
    private Slider _healthBar;

    [SerializeField]
    private UnityEvent _onChange;

    private void Start () {
        _healthBar.maxValue = _health.ChargeMax;
        _healthBar.value = 5;
        _healthBar.onValueChanged.AddListener((changeValue) => _onChange.Invoke());
    }

    public void AddHealth (int health) {
        _healthBar.value += health;
    }

    public void RemoveHealth (int health) {
        _healthBar.value -= health;
    }
}
```

For a full example please see the `Assets/Examples` folder.

## Installation

Unity Gauges is used through [Unity's Package Manager](https://docs.unity3d.com/Manual/CustomPackages.html). In order to use it you'll need to add the following lines to your `Packages/manifest.json` file. After that you'll be able to visually control what specific version of Unity Gauges you're using from the package manager window in Unity. This has to be done so your Unity editor can connect to NPM's package registry.

```json
{
  "scopedRegistries": [
    {
      "name": "NPM",
      "url": "https://registry.npmjs.org",
      "scopes": [
        "com.fluid"
      ]
    }
  ],
  "dependencies": {
    "com.fluid.unity-gauges": "1.0.0"
  }
}
```

## Releases

Archives of specific versions and release notes are available on the [releases page](https://github.com/ashblue/unity-gauges/releases).

## Nightly Builds

To access nightly builds of the `develop` branch that are package manager friendly, you'll need to manually edit your `Packages/manifest.json` as so. 

```json
{
    "dependencies": {
      "com.fluid.unity-gauges": "https://github.com/ashblue/unity-gauges.git#nightly"
    }
}
```

Note that to get a newer nightly build you must delete this line and any related lock data in the manifest, let Unity rebuild, then add it back. As Unity locks the commit hash for Git urls as packages.

## Development Environment

If you wish to run the development environment you'll need to install the [Node.js](https://nodejs.org/en/) version in the [.nvmrc](.nvmrc) file. The easiest way to do this is install [NVM](https://github.com/nvm-sh/nvm) and run `nvm use`. 

Once you've installed Node.js, run the following from the root once.

`npm install`

If you wish to create a build run `npm run build` from the root and it will populate the `dist` folder.

### Making Commits

All commits should be made using [Commitizen](https://github.com/commitizen/cz-cli) (which is automatically installed when running `npm install`). Commits are automatically compiled to version numbers on release so this is very important. PRs that don't have Commitizen based commits will be rejected.

To make a commit type the following into a terminal from the root.

```bash
npm run commit
```

### How To Contribute

Please see the [CONTRIBUTIONS.md](./CONTRIBUTING.md) file for full details on how to contribute to this project.

---

This project was generated with [Oyster Package Generator](https://github.com/ashblue/oyster-package-generator).
