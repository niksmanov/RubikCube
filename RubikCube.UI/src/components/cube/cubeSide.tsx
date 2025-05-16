import * as types from '../../common/types';
export default function CubeSide({ side, name }: { side: types.CubeSide, name: string }) {
    return (<div className={`side ${name}`}>
        {side.facelets.map((f, i) => {
            return <div key={i} data-row={f.row} data-col={f.column} className={`sticker ${f.color.toLowerCase()}`} />
        })}
    </div>);
}