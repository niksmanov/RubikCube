export enum CubeRotation {
    FrontClockwise = "FrontClockwise",
    FrontCounterClockwise = "FrontCounterClockwise",
    BackClockwise = "BackClockwise",
    BackCounterClockwise = "BackCounterClockwise",
    UpClockwise = "UpClockwise",
    UpCounterClockwise = "UpCounterClockwise",
    DownClockwise = "DownClockwise",
    DownCounterClockwise = "DownCounterClockwise",
    LeftClockwise = "LeftClockwise",
    LeftCounterClockwise = "LeftCounterClockwise",
    RightClockwise = "RightClockwise",
    RightCounterClockwise = "RightCounterClockwise",
}

export interface Cube {
    frontSide: CubeSide;
    backSide: CubeSide;
    upSide: CubeSide;
    downSide: CubeSide;
    leftSide: CubeSide;
    rightSide: CubeSide;
}

export interface CubeSide {
    facelets: CubeFacelet[]
}

export interface CubeFacelet {
    column: number;
    row: number;
    color: string;
}