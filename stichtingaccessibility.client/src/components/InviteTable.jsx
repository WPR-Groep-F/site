import React, { useState } from 'react';
import { Table, Button, Modal } from 'react-bootstrap';
import { useQuery } from 'react-query';
import axiosInstance from "../Services/axiosInstance.js";
import {apiPath} from "../util/api.jsx";
import ModalCss from './InviteTable.module.css'

const DataTable = () => {
    const [showModal, setShowModal] = useState(false);
    const [currentItem, setCurrentItem] = useState(null);
    const { data, isLoading, error } = useQuery('tableData', () => axiosInstance.get(`${apiPath}/api/BeheerderPortaal/InviteBedrijf`));

    const handleOpenModal = (item) => {
        setCurrentItem({
            ...item,
            inviteLink: `${apiPath}/bedrijf/register?identifier=${item.indetifier}`
        });
        setShowModal(true);
    };

    const handleCloseModal = () => {
        setShowModal(false);
    };

    if (isLoading) return 'Loading...';
    if (error) return 'An error has occurred: ' + error.message;

    return (
        <>
            <Table striped bordered hover>
                <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th className="d-none d-sm-table-cell">Used</th>
                    <th className="d-none d-sm-table-cell">Expired</th>
                    <th className="d-none d-sm-table-cell">Created by</th>
                    <th className="d-none d-sm-table-cell">Receiver</th>
                    <th>Invite Link</th>
                </tr>
                </thead>
                <tbody>
                {Array.isArray(data.data) ? data.data.map((item) => (
                    <tr key={item.indetifier} onClick={() => handleOpenModal(item)}>
                        <td>{item.naam}</td>
                        <td>{item.email}</td>
                        <td className="d-none d-sm-table-cell">{item.isGebruikt ? 'Yes' : 'No'}</td>
                        <td className="d-none d-sm-table-cell">{item.isVerval ? 'Yes' : 'No'}</td>
                        <td className="d-none d-sm-table-cell">{item.uitgever}</td>
                        <td className="d-none d-sm-table-cell">{item.ontvanger || 'N/A'}</td>
                        <td>
                            <Button variant="primary">
                                Invite Link
                            </Button>
                        </td>
                    </tr>
                )) : <tr><td colSpan="7">No data available</td></tr>}
                </tbody>
            </Table>

            <Modal show={showModal} onHide={handleCloseModal} className={ModalCss["modal-mobile"]}>
                <Modal.Header closeButton>
                    <Modal.Title>Identifier</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    {currentItem && (
                        <>
                            <p>Name: {currentItem.naam}</p>
                            <p>Email: {currentItem.email}</p>
                            <p>Used: {currentItem.isGebruikt ? 'Yes' : 'No'}</p>
                            <p>Expired: {currentItem.isVerval ? 'Yes' : 'No'}</p>
                            <p>Created by: {currentItem.uitgever}</p>
                            <p>Receiver: {currentItem.ontvanger || 'N/A'}</p>
                            <p>Invite Link: <a href={currentItem.inviteLink}>Copy this</a></p>
                        </>
                    )}
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseModal}>
                        Close
                    </Button>
                    {currentItem && (
                        <Button variant="primary" onClick={() => navigator.clipboard.writeText(currentItem.inviteLink)}>
                            Copy Link
                        </Button>
                    )}
                </Modal.Footer>
            </Modal>
        </>
    );
};

export default DataTable;