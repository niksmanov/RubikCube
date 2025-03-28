import '../../styles/components/cube/cube.css';
import Error from '../shared/error/error';
import CubeSide from './cubeSide';
import { useEffect, useState } from 'react';
import * as types from '../../common/types';

export default function Cube() {
    const [cube, setCube] = useState<types.Cube>();
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        populateInitialCubeData();
    }, []);

    const content = cube === undefined
        ? <p><em>Loading... please refresh the page</em></p>
        : <div>
            <div>
                <div className="cubeContainer">
                    <CubeSide side={cube.upSide} name={'upSide'} />
                    <CubeSide side={cube.frontSide} name={'frontSide'} />
                    <CubeSide side={cube.leftSide} name={'leftSide'} />
                    <CubeSide side={cube.rightSide} name={'rightSide'} />
                    <CubeSide side={cube.backSide} name={'backSide'} />
                    <CubeSide side={cube.downSide} name={'downSide'} />
                </div>

                <div className="cubeButtons">
                    <button title="Front Clockwise" onClick={() => rotateCube(types.CubeRotation.FrontClockwise)}> F </button>
                    <button title="Right Clockwise" onClick={() => rotateCube(types.CubeRotation.RightClockwise)}> R </button>
                    <button title="Up Clockwise" onClick={() => rotateCube(types.CubeRotation.UpClockwise)}> U </button>
                    <button title="Back Clockwise" onClick={() => rotateCube(types.CubeRotation.BackClockwise)}> B </button>
                    <button title="Left Clockwise" onClick={() => rotateCube(types.CubeRotation.LeftClockwise)}> L </button>
                    <button title="Down Clockwise" onClick={() => rotateCube(types.CubeRotation.DownClockwise)}> D </button>

                    <button title="Front Counter Clockwise" onClick={() => rotateCube(types.CubeRotation.FrontCounterClockwise)}> F' </button>
                    <button title="Right Counter Clockwise" onClick={() => rotateCube(types.CubeRotation.RightCounterClockwise)}> R' </button>
                    <button title="Up Counter Clockwise" onClick={() => rotateCube(types.CubeRotation.UpCounterClockwise)}> U' </button>
                    <button title="Back Counter Clockwise" onClick={() => rotateCube(types.CubeRotation.BackCounterClockwise)}> B' </button>
                    <button title="Left Counter Clockwise" onClick={() => rotateCube(types.CubeRotation.LeftCounterClockwise)}> L' </button>
                    <button title="Down Counter Clockwise" onClick={() => rotateCube(types.CubeRotation.DownCounterClockwise)}> D' </button>
                </div>
                <button className="resetState" onClick={() => populateInitialCubeData()}> Reset </button>
            </div>

            <Error message={error} />
        </div>;

    return content;

    async function populateInitialCubeData() {
        const response = await fetch('/api/cube/get-cube');
        if (response.ok) {
            const data = await response.json();
            setCube(data);
            setError(null);
        } else {
            const error = await response.text();
            setError(error);
        }
    }

    async function rotateCube(rotation: types.CubeRotation) {
        const response = await fetch('/api/cube/rotate-cube',
            {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(rotation)
            });
        if (response.ok) {
            const data = await response.json();
            setCube(data);
            setError(null);
        } else {
            const error = await response.text();
            setError(error);
        }
    }
}